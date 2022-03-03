using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using UnityEngine;

namespace WBML
{
    public class WorldBoxMod : MonoBehaviour
    {
        private const string Path = "./Mods";

        private static bool _initialized;

        private ModHandler _modHandler;

        private void Update()
        {
            if (!Config.gameLoaded)
            {
                return;
            }

            if (!_initialized)
            {
                IEnumerable<Assembly> modAssemblies = GetModAssemblies();
                Initialize(modAssemblies);
            }
            
            _modHandler.UpdateMods();
        }

        private IEnumerable<Assembly> GetModAssemblies()
        {
            if (!Directory.Exists(Path))
            {
                return Array.Empty<Assembly>();
            }
            
            List<Assembly> modAssemblies = new List<Assembly>();
            
            string[] fileNames = Directory.GetFiles(Path);
            foreach (string fileName in fileNames)
            {
                try
                {
                    Assembly assembly = Assembly.LoadFrom(fileName);
                    modAssemblies.Add(assembly);
                }
                catch
                {
                    Console.WriteLine("Failed to load mod {0}", fileName);
                }
            }

            return modAssemblies;
        }

        private void Initialize(IEnumerable<Assembly> modAssemblies)
        {
            _modHandler = new ModHandler(modAssemblies);
            _initialized = true;
        }
    }
}