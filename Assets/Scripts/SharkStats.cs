using UnityEngine;

[CreateAssetMenu(fileName = "SharkStats", menuName = "Shark Stats", order = 0)]
public class SharkStats : ScriptableObject
{
        [SerializeField]
        private int love, hunger, thirst, sleepiness, healthPoints;

        public int Love
        {
                get => love;
                set => love = value;
        }
        public int Hunger
        {
                get => hunger;
                set => hunger = value;
        }
        public int Thirst
        {
                get => thirst;
                set => thirst = value;
        }
        public int Sleepiness
        {
                get => sleepiness;
                set => sleepiness = value;
        }
        public int HealthPoints
        {
                get => healthPoints;
                set => healthPoints = value;
        }
}