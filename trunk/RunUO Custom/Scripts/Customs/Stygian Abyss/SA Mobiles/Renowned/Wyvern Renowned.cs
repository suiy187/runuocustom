using System;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a wyvern corpse" )]
	public class WyvernRenowned : BaseCreature
	{
		[Constructable]
		public WyvernRenowned () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a Wyvern [Renowned]";
			Body = 62;
			Hue = 37;
			BaseSoundID = 362;

			SetStr( 1370, 1422 );
			SetDex( 103, 151 );
			SetInt( 835, 1002 );

			SetHits( 2412, 2734 );

			SetDamage( 29, 35 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Poison, 50 );

			SetResistance( ResistanceType.Physical, 65, 67 );
			SetResistance( ResistanceType.Fire, 81, 90 );
			SetResistance( ResistanceType.Cold, 72, 79 );
			SetResistance( ResistanceType.Poison, 65, 68 );
			SetResistance( ResistanceType.Energy, 60, 70 );

			SetSkill( SkillName.Poisoning, 60.1, 80.0 );
			SetSkill( SkillName.MagicResist, 125.8, 127.6 );
			SetSkill( SkillName.Tactics, 112.8, 123.7 );
			SetSkill( SkillName.Wrestling, 108.6, 109.4 );

			Fame = 4000;
			Karma = -4000;

			VirtualArmor = 40;
			
			PackItem( new LesserPoisonPotion() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.SuperBoss, 1 );
		}

		public override bool ReacquireOnMovement{ get{ return true; } }

		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }
		public override Poison HitPoison{ get{ return Poison.Deadly; } }
		public override int TreasureMapLevel{ get{ return 2; } }

		public override int Meat{ get{ return 10; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Horned; } }

		public override int GetAttackSound()
		{
			return 713;
		}

		public override int GetAngerSound()
		{
			return 718;
		}

		public override int GetDeathSound()
		{
			return 716;
		}

		public override int GetHurtSound()
		{
			return 721;
		}

		public override int GetIdleSound()
		{
			return 725;
		}

		public WyvernRenowned( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}