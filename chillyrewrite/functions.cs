using System.Diagnostics;

namespace chillyrewrite
{
    public class methods
    {
        Mem m = new Mem();
        public string replacelastoffset(string cum, string replace)
        {
            int lastCommaIndex = cum.ToString().LastIndexOf(",");
            string result = cum.ToString().Substring(0, lastCommaIndex);
            return result + "," + replace;
        }
        public Entity ReadEntity(string address)
        {
            var ent = new Entity();

            ent.baseAddress = m.ReadInt(address);

            ent.hitbox = new Vector2(m.ReadFloat(offset.iEntityList + offset.v2Hitbox),
                                     m.ReadFloat(offset.iEntityList + replacelastoffset(offset.v2Hitbox, "1C")));

            ent.feet = new Vector3(m.ReadFloat(offset.iEntityList + offset.v3Feet),
                                   m.ReadFloat(offset.iEntityList + replacelastoffset(offset.v3Feet, "10")),
                                   m.ReadFloat(offset.iEntityList + replacelastoffset(offset.v3Feet, "14")));

            ent.head = new Vector3(m.ReadFloat(offset.iEntityList + offset.v3Head),
                                   m.ReadFloat(offset.iEntityList + replacelastoffset(offset.v3Head, "4")),
                                   m.ReadFloat(offset.iEntityList + replacelastoffset(offset.v3Head, "8")));

            ent.velocity = new Vector3(m.ReadFloat(offset.iEntityList + offset.v3Velocity),
                                       m.ReadFloat(offset.iEntityList + replacelastoffset(offset.v3Velocity, "1C")),
                                       m.ReadFloat(offset.iEntityList + replacelastoffset(offset.v3Velocity, "20")));

            ent.type = m.ReadString(offset.iEntityList + offset.sType);

            return ent;
        }

        public List<Entity> ReadEntityList(Entity localPlayer)
        {
            var entities = new List<Entity>();
            string entitylist = m.ReadInt(offset.iEntityList).ToString();
            Debug.WriteLine(entitylist);

            for (int i = 0; i < 64; i++)
            {
                Entity entity = ReadEntity(entitylist);
                var currentEntBase = m.ReadInt(entitylist + i * 0x4).ToString();
                var ent = ReadEntity(currentEntBase);

                if (entity.type.Contains("player"))
                {
                    entities.Add(entity);
                }
            }
            return entities;
        }

        public void hitboxes(Entity ent, float x, float y)
        {
            m.WriteMemory(offset.iEntityList + offset.v2Hitbox, "float", x.ToString());
            m.WriteMemory(offset.iEntityList + replacelastoffset(offset.v2Hitbox, "1C"), "float", y.ToString());
        }

        public methods()
        {
            m = new Mem();
            m.OpenProcess("minecraft.windows");
        }
    }
}
