using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a Daemon corpse" )]
	public class FireDaemonRenowned : BaseCreature
	{
		[Constructable]
		public FireDaemonRenowned () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Fire Daemon [Renowned]";
			Body = 40;
			BaseSoundID = 357;

			SetStr( 1119 );
			SetDex( 239 );
			SetInt( 226 );

			SetHits( 1186 );

			SetDamage( 22, 29 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Fire, 25 );
			SetDamageType( ResistanceType.Energy, 25 );

			SetResistance( ResistanceType.Physical, 73 );
			SetResistance( ResistanceType.Fire, 75 );
			SetResistance( ResistanceType.Cold, 59 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 40 );

			SetSkill( SkillName.Anatomy, 49.2 );
			SetSkill( SkillName.EvalInt, 96.3 );
			SetSkill( SkillName.Magery, 96.9 );
			SetSkill( SkillName.Meditation, 41.1 );
			SetSkill( SkillName.MagicResist, 125.5 );
			SetSkill( SkillName.Tactics, 95.6 );
			SetSkill( SkillName.Wrestling, 90.7 );

			Fame = 24000;
			Karma = -24000;

			VirtualArmor = 90;

			PackItem( new Longsword() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.MedScrolls, 2 );
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override int Meat{ get{ return 1; } }

		public FireDaemonRenowned( Serial serial ) : base( serial )
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