namespace Ldis_Project_Reliz.Server.BusinesStaticMethod
{
    public static class LevenshtainDistance
    {
        /*Алгоритм дистанции Левенштейна для поиска чатов*/
        public static int Calculate(string source, string target)
        {
            if (string.IsNullOrEmpty(source))
            {
                return (target ?? "").Length;
            }
            if (string.IsNullOrEmpty(target))
            {
                return source.Length;
            }

            if (source[0] == target[0])
            {
                return Calculate(source.Substring(1), target.Substring(1));
            }

            int delete = Calculate(source.Substring(1), target);
            int insert = Calculate(source, target.Substring(1));
            int replace = Calculate(source.Substring(1), target.Substring(1));

            return 1 + Math.Min(Math.Min(delete, insert), replace);
        }
    }
}
