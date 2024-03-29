using System;
using Server;
using Server.Items;
using Server.Spells;
using Server.Spells.Seventh;
using Server.Spells.Fifth;
using System.Collections.Generic;
using System.Collections;
using Server.Misc;

namespace Server.Mobiles
{
    public class GrayGoblinMageRenowned : BaseRenowned
	{
		public override Type[] UniqueSAList{ get { return new Type[] {typeof( CavalrysFolly ) }; }}
        public override Type[] SharedSAList { get { return new Type[] { typeof(CavalrysFolly), typeof(StormCaller), typeof(TorcOfTheGuardians), typeof(GiantSteps) }; } }
            
		public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.Orc; } }

		[Constructable]
		public GrayGoblinMageRenowned() : base( AIType.AI_Mage )
		{
			Name = "Gray Goblin Mage";
			Title = "[Renowned]";
			Body = 42;
			BaseSoundID = 437;

			SetStr( 550, 600 );
			SetDex( 70, 75 );
			SetInt( 500, 600 );

			SetHits( 1100, 1300 );

			SetDamage( 5, 7 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30, 35 );
			SetResistance( ResistanceType.Fire, 45, 50 );
			SetResistance( ResistanceType.Cold, 40, 50 );
			SetResistance( ResistanceType.Poison, 40, 50 );
			SetResistance( ResistanceType.Energy, 20, 25 );

			SetSkill( SkillName.MagicResist, 120.0, 125.0 );
			SetSkill( SkillName.Tactics, 95.0, 100.0 );
			SetSkill( SkillName.Wrestling, 100.0, 110.0 );
			SetSkill( SkillName.EvalInt, 100.0, 120.0 );
			SetSkill( SkillName.Meditation, 100.0, 105.0 );
			SetSkill( SkillName.Magery, 100.0, 110.0 );

			Fame = 1500;
			Karma = -1500;

			VirtualArmor = 28;

                        PackItem( new EssenceControl() );
			
			switch ( Utility.Random( 20 ) )
			{
				case 0: PackItem( new Scimitar() ); break;
				case 1: PackItem( new Katana() ); break;
				case 2: PackItem( new WarMace() ); break;
				case 3: PackItem( new WarHammer() ); break;
				case 4: PackItem( new Kryss() ); break;
				case 5: PackItem( new Pitchfork() ); break;
			}

			PackItem( new ThighBoots() );

			switch ( Utility.Random( 3 ) )
			{
				case 0: PackItem( new Ribs() ); break;
				case 1: PackItem( new Shaft() ); break;
				case 2: PackItem( new Candle() ); break;
			}

			if ( 0.2 > Utility.RandomDouble() )
				PackItem( new BolaBall() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
			
		}
		
		
		public GrayGoblinMageRenowned( Serial serial ) : base( serial )
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