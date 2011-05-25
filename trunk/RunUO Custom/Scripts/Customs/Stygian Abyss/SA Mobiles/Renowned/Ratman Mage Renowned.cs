using System;
using System.Collections;
using Server.Misc;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a glowing ratman corpse" )]
	public class RatmanMageRenowned : BaseCreature
	{
		public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.Ratman; } }

		[Constructable]
		public RatmanMageRenowned() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = " Vitavi [Renowned]";
			Body = 0x8F;
			BaseSoundID = 437;

			SetStr( 309, 345 );
			SetDex( 270, 287 );
			SetInt( 311, 343 );

			SetHits( 50000 );

			SetDamage( 7, 14 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 50, 58 );
			SetResistance( ResistanceType.Fire, 31, 45 );
			SetResistance( ResistanceType.Cold, 60, 78 );
			SetResistance( ResistanceType.Poison, 21, 28 );
			SetResistance( ResistanceType.Energy, 32, 37 );

			SetSkill( SkillName.EvalInt, 70.1, 80.0 );
			SetSkill( SkillName.Magery, 70.1, 80.0 );
			SetSkill( SkillName.MagicResist, 89.1, 100.0 );
			SetSkill( SkillName.Tactics, 67.6, 72.2 );
			SetSkill( SkillName.Wrestling, 70.0, 71.8 );

			Fame = 7500;
			Karma = -7500;

			VirtualArmor = 44;

			PackReg( 6 );

			if ( 0.02 > Utility.RandomDouble() )
				PackStatue();
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.SuperBoss, 1 );
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 8; } }
		public override HideType HideType{ get{ return HideType.Spined; } }

		public RatmanMageRenowned( Serial serial ) : base( serial )
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

			if ( Body == 42 )
			{
				Body = 0x8F;
				Hue = 0;
			}
		}
	}
}
