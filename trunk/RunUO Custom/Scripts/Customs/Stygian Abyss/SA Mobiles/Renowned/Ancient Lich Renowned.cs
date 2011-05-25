using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "an ancient liche's corpse" )]
	public class AncientLichRenowned : BaseCreature
	{
		[Constructable]
		public AncientLichRenowned() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an ancient lich [Renowned]";
			Body = 78;
			BaseSoundID = 412;

			SetStr( 299 );
			SetDex( 113 );
			SetInt( 1010 );

			SetHits( 2242 );

			SetDamage( 15, 27 );

			SetDamageType( ResistanceType.Physical, 20 );
			SetDamageType( ResistanceType.Cold, 40 );
			SetDamageType( ResistanceType.Energy, 40 );

			SetResistance( ResistanceType.Physical, 61 );
			SetResistance( ResistanceType.Fire, 28 );
			SetResistance( ResistanceType.Cold, 56 );
			SetResistance( ResistanceType.Poison, 60 );
			SetResistance( ResistanceType.Energy, 28 );

			SetSkill( SkillName.EvalInt, 127.2 );
			SetSkill( SkillName.Magery, 127.2 );
			SetSkill( SkillName.Meditation, 100.2 );
			SetSkill( SkillName.MagicResist, 187.1 );
			SetSkill( SkillName.Tactics, 91.7 );
			SetSkill( SkillName.Wrestling, 98.5 );

			Fame = 23000;
			Karma = -23000;

			VirtualArmor = 60;
			PackNecroReg( 30, 275 );			
		}

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.FeyAndUndead; }
		}

		public override int GetIdleSound()
		{
			return 0x19D;
		}

		public override int GetAngerSound()
		{
			return 0x175;
		}

		public override int GetDeathSound()
		{
			return 0x108;
		}

		public override int GetAttackSound()
		{
			return 0xE2;
		}

		public override int GetHurtSound()
		{
			return 0x28B;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 3 );
			AddLoot( LootPack.MedScrolls, 2 );
		}

		public override bool Unprovokable{ get{ return true; } }
		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override int TreasureMapLevel{ get{ return 5; } }

        public AncientLichRenowned(Serial serial)
            : base(serial)
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