using System;
using Server;
using Server.Targeting;
using Server.Mobiles;
using Server.Items;
using System.Collections;
using System.Collections.Generic;
using Server.ContextMenus;

namespace Server.Items
{
	public class YellowKey1 : AbyssKey
	{
        public override int LabelNumber { get { return 1111648; } } //Yellow Key
        public override int Lifespan { get { return 21600; } }

        [Constructable]
		public YellowKey1() : base( 0x1012 )
		{
			Hue = 0x489;
            		Weight = 1.0;
            		Movable = false;
		}

        public override void OnDoubleClick(Mobile m)
        {
            	Item a = m.Backpack.FindItemByType(typeof(RedKey1));
            	if (a != null)
            	{
                Item b = m.Backpack.FindItemByType(typeof(BlueKey1));
                if (b != null)
                {
          		m.AddToBackpack(new TripartiteKey());
                        a.Delete();
                        b.Delete();
                        this.Delete();
                        m.SendLocalizedMessage(1111649);
                }
            }
    	}
        
             	
	public YellowKey1( Serial serial ) : base( serial )
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