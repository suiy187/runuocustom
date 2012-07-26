using System;

namespace Server.Items
{
	public class RareSerpentEgg4 : PeerlessKey
	{
        public override int LabelNumber { get { return 1112575; } } // a rare serpent egg
        public override int Lifespan { get { return 43200; } }

		[Constructable]
		public RareSerpentEgg4() : base( 0x41BF )
		{
			Weight = 1.0;
			Hue = 2121;
		}

		public RareSerpentEgg4( Serial serial ) : base( serial )
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

