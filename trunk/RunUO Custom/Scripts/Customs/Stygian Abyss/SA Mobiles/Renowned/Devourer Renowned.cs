using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a Devourer of souls corpse" )]
	public class DevourerRenowned : BaseCreature
	{
		[Constructable]
		public DevourerRenowned() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a Devourer of souls [Renowned]";
			Body = 303;
			BaseSoundID = 357;

			SetStr( 910 );
			SetDex( 132 );
			SetInt( 230 );

			SetHits( 1892 );

			SetDamage( 22, 26 );

			SetDamageType( ResistanceType.Physical, 60 );
			SetDamageType( ResistanceType.Cold, 20 );
			SetDamageType( ResistanceType.Energy, 20 );

			SetResistance( ResistanceType.Physical, 51 );
			SetResistance( ResistanceType.Fire, 25 );
			SetResistance( ResistanceType.Cold, 20 );
			SetResistance( ResistanceType.Poison, 68 );
			SetResistance( ResistanceType.Energy, 47 );

			SetSkill( SkillName.EvalInt, 92.8 );
			SetSkill( SkillName.Magery, 98.8 );
			SetSkill( SkillName.Meditation, 91.7 );
			SetSkill( SkillName.MagicResist, 94.2 );
			SetSkill( SkillName.Tactics, 76.4 );
			SetSkill( SkillName.Wrestling, 97.4 );

			Fame = 9500;
			Karma = -9500;

			VirtualArmor = 44;

			PackNecroReg( 24, 45 );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
		}

		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

		public override int Meat{ get{ return 3; } }

		public DevourerRenowned( Serial serial ) : base( serial )
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