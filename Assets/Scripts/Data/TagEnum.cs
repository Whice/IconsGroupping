namespace Assets.Scripts.Data
{
    public enum TagEnum:int
    {
        hero = 1,
        item,
        skill,
        strength,
        agility,
        intelligence,
        universal,
    }

    public static class TagEnumExtensions
    {
        public static int GetInt(this TagEnum tag)
        {
            return (int)tag;
        }
        public static string GetName(this TagEnum tag)
        {
            return tag.ToString();
        }
    }
}