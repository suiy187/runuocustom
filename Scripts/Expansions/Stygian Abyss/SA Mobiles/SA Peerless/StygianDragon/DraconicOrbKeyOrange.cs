using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class DraconicOrbKeyOrange : PeerlessKey
	{	
		public override int Lifespan{ get{ return 21600; } }
		public override int LabelNumber{ get{ return 1113515; } } // Draconic Orb
	
		[Constructable]
		public DraconicOrbKeyOrange() : base( 0x573F )
		{
			Weight = 1;
			Hue = 1260; // TODO check
		}

		public DraconicOrbKeyOrange( Serial serial ) : base( serial )
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

