using System;
using Server;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server.Items;
using System.Collections;
using System.Collections.Generic;

namespace Server.Commands
{
    public class AddCloneCommands
    {
        public static void Initialize()
        {
            CommandSystem.Register("addclone", AccessLevel.Seer, new CommandEventHandler(AddClone_OnCommand));
        }

        [Description("")]
        public static void AddClone_OnCommand(CommandEventArgs e)
        {
            BaseCreature clone = new MedusaClone(e.Mobile);
            clone.Frozen = clone.Blessed = true;
            clone.MoveToWorld(e.Mobile.Location, e.Mobile.Map);
        }
    }
}

namespace Server.Mobiles
{
    public class MedusaClone : BaseCreature, IFreezable
    {
        public MedusaClone(Mobile m)
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            SolidHueOverride = 33;
            Clone(m);
        }

        public void Clone(Mobile m)
        {
            if (m == null)
            {
                Delete();
                return;
            }

            Body = m.Body;

            Str = m.Str;
            Dex = m.Dex;
            Int = m.Int;

            Hits = m.HitsMax;

            Hue = m.Hue;
            Female = m.Female;

            Name = m.Name;
            NameHue = m.NameHue;

            Title = m.Title;
            Kills = m.Kills;

            HairItemID = m.HairItemID;
            HairHue = m.HairHue;

            FacialHairItemID = m.FacialHairItemID;
            FacialHairHue = m.FacialHairHue;

            BaseSoundID = m.BaseSoundID;


            for (int i = 0; i < m.Skills.Length; ++i)
            {
                Skills[i].Base = m.Skills[i].Base;
                Skills[i].Cap = m.Skills[i].Cap;
            }

            for (int i = 0; i < m.Items.Count; i++)
            {
                if (m.Items[i].Layer != Layer.Backpack && m.Items[i].Layer != Layer.Mount && m.Items[i].Layer != Layer.Bank)
                    AddItem(CloneItem(m.Items[i]));
            }
        }

        public Item CloneItem(Item item)
        {
            Item cloned = new Item(item.ItemID);
            cloned.Layer = item.Layer;
            cloned.Name = item.Name;
            cloned.Hue = item.Hue;
            cloned.Weight = item.Weight;
            cloned.Movable = false;

            return cloned;
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (Frozen)
                DisplayPaperdollTo(from);
            else
                base.OnDoubleClick(from);
        }

        public void OnRequestedAnimation(Mobile from)
        {
            if (Frozen)
            {
                //if (Core.SA)
                    //from.Send(new UpdateStatueAnimationSA(this, 31, 5));
                //else
                    from.Send(new UpdateStatueAnimation(this, 1, 31, 5));
            }
        }

        public override bool DeleteCorpseOnDeath { get { return true; } }

        public override void OnDelete()
        {
            Effects.SendLocationParticles(EffectItem.Create(Location, Map, EffectItem.DefaultDuration), 0x3728, 10, 15, 5042);

            base.OnDelete();
        }

        public override bool ReacquireOnMovement { get { return true; } }
        public override bool AlwaysMurderer { get { return !Frozen; } }

        public MedusaClone(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
            Delete();
        }
    }
}