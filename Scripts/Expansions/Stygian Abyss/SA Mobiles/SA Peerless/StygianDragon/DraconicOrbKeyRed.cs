using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class DraconicOrbKeyRed : PeerlessKey
	{	
		public override int Lifespan{ get{ return 21600; } }
		public override int LabelNumber{ get{ return 1113515; } } // Draconic Orb
	
		[Constructable]
		public DraconicOrbKeyRed() : base( 0x573F )
		{
			Weight = 1;
			Hue = 33; // TODO check
		}

		public DraconicOrbKeyRed( Serial serial ) : base( serial )
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

