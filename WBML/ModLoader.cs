using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WBML.Core;

namespace WBML
{
    internal class ModHandler
    {
        private readonly Mod[] _mods;
        
        public ModHandler(IEnumerable<Assembly> modAssemblies)
        {
            List<Mod> mods = new List<Mod>();

            foreach (Assembly modAssembly in modAssemblies)
            {
                Type type = modAssembly.GetTypes()
                    .Single(x => typeof(Mod).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);

                Mod mod = (Mod)Activator.CreateInstance(type);
                mods.Add(mod);
            }
            
            _mods = mods.ToArray();

            InitializeMods();
        }

        private void InitializeMods()
        {
            foreach (Mod mod in _mods)
            {
                mod.Initialize();
            }
        }

        public void UpdateMods()
        {
            foreach (Mod mod in _mods)
            {
                mod.Update();
            }
        }
    }
}