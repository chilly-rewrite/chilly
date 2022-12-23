using Memory;
using System.Numerics;

namespace chillyrewrite
{
    public class methods
    {
        Mem m = new Mem();
        public string replacelastoffset(string cum)
        {
            int lastCommaIndex = cum.ToString().LastIndexOf(",");
            string result = cum.ToString().Substring(0, lastCommaIndex);
            return result;
        }
        public Entity ReadEntity()
        {
            var ent = new Entity();

            ent.hitbox = new Vector2(m.ReadFloat(offset.iEntityList + offset.v2Hitbox),
                                     m.ReadFloat(offset.iEntityList + replacelastoffset(offset.v2Hitbox) + ",1C"));

            ent.feet = new Vector3(m.ReadFloat(offset.iEntityList + offset.v3Feet),
                                   m.ReadFloat(offset.iEntityList + replacelastoffset(offset.v3Feet) + ",10"),
                                   m.ReadFloat(offset.iEntityList + replacelastoffset(offset.v3Feet) + ",14"));

            ent.head = new Vector3(m.ReadFloat(offset.iEntityList + offset.v3Head),
                                   m.ReadFloat(offset.iEntityList + replacelastoffset(offset.v3Head) + ",4"),
                                   m.ReadFloat(offset.iEntityList + replacelastoffset(offset.v3Head) + ",8"));

            ent.velocity = new Vector3(m.ReadFloat(offset.iEntityList + offset.v3Velocity),
                                       m.ReadFloat(offset.iEntityList + replacelastoffset(offset.v3Velocity) + ",1C"),
                                       m.ReadFloat(offset.iEntityList + replacelastoffset(offset.v3Velocity) + ",20"));

            ent.type = m.ReadString(offset.iEntityList + offset.sType);

            return ent;
        }

        public methods()
        {
            m = new Mem();
            m.OpenProcess("minecraft.windows");
        }
    }
}
