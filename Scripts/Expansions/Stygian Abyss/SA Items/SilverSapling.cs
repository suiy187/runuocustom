using System;
using System.Collections.Generic;
using Server;
using Server.Mobiles;
using Server.ContextMenus;

namespace Server.Items
{
	public class SilverSapling : Item
	{
		public override int LabelNumber { get{return 1113052;}}

        [Constructable]
		public SilverSapling() : base( 0x0CE3 )
		{
            Hue = 1150;
			Movable = false;
		}

		public override bool HandlesOnMovement{ get{ return true; } } // Tell the core that we implement OnMovement

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( Parent == null && Utility.InRange( Location, m.Location, 1 ) && !Utility.InRange( Location, oldLocation, 1 ) )
				Ankhs.Resurrect( m, this );
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );
			Ankhs.GetContextMenuEntries( from, this, list );
		}

		public override void OnDoubleClickDead( Mobile m )
		{
			Ankhs.Resurrect( m, this );
		}

		public override void OnDoubleClick( Mobile m )
		{
            PlayerMobile pm = m as PlayerMobile;
            if ( null == pm )
                return;

            // add check for getting silver sapling seed only once per day...
            if ( pm.SSNextSeed > DateTime.Now )
                pm.SendLocalizedMessage(1113042);    // You must wait a full day before receiving another Seed of the Silver Sapling
            else
            {
                pm.SendLocalizedMessage(1113043);    // The Silver Sapling pulses with light, and a shining seed appears in your hands.
                pm.SSNextSeed = DateTime.Now + TimeSpan.FromDays(1.0);

                Item item = new SilverSaplingSeed();
				Container pack = pm.Backpack;
				if( pack == null )
					pm.AddToBackpack( item );
				else
					pack.DropItem( item );
            }
		}

		public SilverSapling( Serial serial ) : base( serial )
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

	public class SilverSaplingSeed : Item
	{
		public override int LabelNumber { get{return 1113053;}}

        [Constructable]
		public SilverSaplingSeed() : base( 0x0DCF )
		{
            Hue = 1150;
		}

		public override void OnDoubleClick( Mobile m )
		{
            PlayerMobile pm = m as PlayerMobile;
            if ( null == pm )
                return;

            if ( pm.Region.IsPartOf("Abyss") )
            {
                pm.SendLocalizedMessage(1113056);    // The seed disappears into the earth and for a brief moment you see a vision of a small sapling growing before you. Should you perish in your adventures in the Abyss, you shall be restored to this place with your possessions.
                Delete();
                pm.SSSeedLocation = pm.Location; 
                pm.SSSeedMap = pm.Map; 
                pm.SSSeedExpire = DateTime.Now + TimeSpan.FromDays(1.0);
            }
            else
                pm.SendLocalizedMessage(1113055);    // The seed of the Silver Sapling can only be planted within the Stygian Abyss...    
		}

		public SilverSaplingSeed( Serial serial ) : base( serial )
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
