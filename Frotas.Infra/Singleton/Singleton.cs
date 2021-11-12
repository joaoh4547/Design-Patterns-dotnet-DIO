using System;
using System.Collections.Generic;
using System.Text;


namespace Frotas.Infra.Singleton
{
    public sealed class Singleton
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        private static Singleton instance;

        private Singleton()
        {

        }

        public static Singleton Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
    }
}
