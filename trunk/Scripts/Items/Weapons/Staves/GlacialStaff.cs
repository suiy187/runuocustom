using System;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Network;
using Server.Spells;
using Server.Targeting;

namespace Server.Items
{
	public enum GlacialStaffEffect
	{
		Freeze,
		IceStrike,
		IceBall
	}

	public class GlacialStaff : BlackStaff
	{
		//TODO: Pre-AoS stuff
		public override int LabelNumber{ get{ return 1017413; } } // Glacial Staff

		[Constructable]
		public GlacialStaff()
		{
			Hue = 0x480;
			WeaponAttributes.HitHarm = 5 * Utility.RandomMinMax( 1, 5 );
			WeaponAttributes.MageWeapon = Utility.RandomMinMax( 5, 10 );

			AosElementDamages[AosElementAttribute.Cold] = 20 + (5 * Utility.RandomMinMax( 0, 6 ));

			m_Limit = Utility.Random( 3 );
		}

		#region That_Pre-AOS_Stuff
		private int m_Limit;
		private int m_Charges;
		private GlacialStaffEffect m_StaffEffect;

		[CommandProperty( AccessLevel.GameMaster )]
		public int Limit
		{
			get { return m_Limit; }
			set
			{
				if ( value < 0 )
					value = 0;
				else if ( value > 2 )
					value = 2;

				m_Limit = value;
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int Charges
		{
			get { return m_Charges; }
			set { m_Charges = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public GlacialStaffEffect Effect
		{
			get { return m_StaffEffect; }
			set { m_StaffEffect = value; }
		}

		public override bool HandlesOnSpeech{ get{ return (Parent is Mobile); } }

		public override void OnSpeech( SpeechEventArgs e )
		{
			base.OnSpeech( e );

			if ( e.Mobile.FindItemOnLayer( Layer.TwoHanded ) != this )
				return;

			string said = e.Speech.ToLower();

			if ( said == "an ex del" && m_Limit != 0 )
				m_StaffEffect = GlacialStaffEffect.Freeze;
			else if ( said == "in corp del" && m_Limit != 1 )
				m_StaffEffect = GlacialStaffEffect.IceStrike;
			else if ( said == "des corp del" && m_Limit != 2 )
				m_StaffEffect = GlacialStaffEffect.IceBall;
		}

		public override void AddNameProperty( ObjectPropertyList list )
		{
			base.AddNameProperty( list );

			list.Add( m_StaffEffect.ToString() );

			if ( m_Charges != 0 )
				list.Add( 1060584, m_Charges.ToString() );
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( from.FindItemOnLayer( Layer.TwoHanded ) != this )
				from.SendLocalizedMessage( 502641 ); // You must equip this item to use it.
			else
			{
				switch ( m_StaffEffect )
				{
					case GlacialStaffEffect.Freeze: new FreezeSpell( from, this ).Cast(); break;
					case GlacialStaffEffect.IceStrike: new IceStrikeSpell( from, this ).Cast(); break;
					case GlacialStaffEffect.IceBall: new IceBallSpell( from, this ).Cast(); break;
				}
			}
		}

		public void LoseACharge()
		{
			--m_Charges;

			if ( m_Charges < 1 )
			{
				// Cliloc?
				if ( Parent is Mobile )
					((Mobile)Parent).SendMessage( "The staff shatters after being used." );

				Delete();
			}
		}
		#endregion

		public GlacialStaff( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}

namespace Server.Spells
{
	public class GlacialStaffSpell : Spell
	{
		public GlacialStaff Staff;

		public GlacialStaffSpell( Mobile from, GlacialStaff staff, SpellInfo info ) : base( from, null, info )
		{
			Staff = staff;
		}

		public override bool ClearHandsOnCast{ get{ return false; } }
		public override bool RevealOnCast{ get{ return true; } }
		public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds( 1.0 ); } }
		public override TimeSpan GetCastRecovery() { return TimeSpan.FromSeconds( 1.0 ); }
		public override TimeSpan GetCastDelay() { return TimeSpan.FromSeconds( 1.0 ); }
		public override int GetMana() { return 0; }
		public override bool ConsumeReagents() { return true; }
		public override bool CheckFizzle() { return true; }

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public virtual void Target( Mobile m )
		{
		}

		private class InternalTarget : Target
		{
			private GlacialStaffSpell m_Owner;

			public InternalTarget( GlacialStaffSpell owner ) : base( 12, false, TargetFlags.Harmful )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( !m_Owner.Caster.CanSee( o ) )
					m_Owner.Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
				else if ( o is Mobile )
					m_Owner.Target( (Mobile)o );
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();

				if ( m_Owner != null && m_Owner.Staff != null )
					m_Owner.Staff.LoseACharge();
			}
		}
	}

	public class FreezeSpell : GlacialStaffSpell
	{
		private static SpellInfo m_Info = new SpellInfo( "Freeze Spell", "An Ex Del", 230 );

		public FreezeSpell( Mobile from, GlacialStaff staff ) : base( from, staff, m_Info )
		{
		}

		// Correct?
		public override void Target( Mobile m )
		{
			if ( CheckHSequence( m ) )
			{
				SpellHelper.Turn( Caster, m );
				Caster.FixedParticles( 0x374A, 10, 15, 2038, EffectLayer.Head );
				m.FixedParticles( 0x374A, 10, 15, 5038, EffectLayer.Head );
				m.PlaySound( 0x213 );
				m.Paralyze( TimeSpan.FromSeconds( Utility.RandomMinMax( 10, 20 ) ) );
			}

			FinishSequence();
		}
	}

	public class IceStrikeSpell : GlacialStaffSpell
	{
		private static SpellInfo m_Info = new SpellInfo( "IceStrike Spell", "In Corp Del", 230 );

		public IceStrikeSpell( Mobile from, GlacialStaff staff ) : base( from, staff, m_Info )
		{
		}

		public override void Target( Mobile m )
		{
			if ( CheckHSequence( m ) )
			{
				SpellHelper.Turn( Caster, m );
				Caster.FixedParticles( 0x374A, 10, 15, 2038, EffectLayer.Head );
				m.FixedParticles( 0x374A, 10, 15, 5038, EffectLayer.Head );
				m.PlaySound( 0x213 );

				int damage = Caster.Mana / 2;
				Caster.Mana = 0;

				SpellHelper.Damage( this, m, damage );
			}

			FinishSequence();
		}
	}

	public class IceBallSpell : GlacialStaffSpell
	{
		private static SpellInfo m_Info = new SpellInfo( "IceBall Spell", "Des Corp Del", 230 );

		public IceBallSpell( Mobile from, GlacialStaff staff ) : base( from, staff, m_Info )
		{
		}

		public override void Target( Mobile m )
		{
			if ( CheckHSequence( m ) )
			{
				SpellHelper.Turn( Caster, m );
				Caster.FixedParticles( 0x374A, 10, 15, 2038, EffectLayer.Head );
				m.FixedParticles( 0x374A, 10, 15, 5038, EffectLayer.Head );
				m.PlaySound( 0x213 );
				SpellHelper.Damage( this, m, Utility.RandomMinMax( 10, 15 ) );
			}

			FinishSequence();
		}
	}
}

