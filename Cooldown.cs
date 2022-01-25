using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace PetrovDA.Utils
{
    public class Cooldown
    {
        public Action<bool> CooldownStatementChanged;
        private bool statement = false;

        public bool Statement { get => statement; }

        public async void SetCooldown(float seconds)
        {
            statement = true;
            CooldownStatementChanged?.Invoke(statement);
            await Task.Delay((int) (seconds * 1000));
            statement = false;
            CooldownStatementChanged?.Invoke(statement);
        }

    }
}
