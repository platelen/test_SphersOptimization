using UnityEngine;

namespace ParticlessControll
{
    [RequireComponent(typeof(ParticleSystem))]
    public class ConstrainParticlesToSphere : MonoBehaviour
    {
        public Vector3 sphereCenter = Vector3.zero;
        public float sphereRadius = 5.0f;
        public float repulsionForce = 1.0f;
        public int maxParticles = 1000; // Новый параметр: количество частиц

        private ParticleSystem particles;

        void Start()
        {
            particles = GetComponent<ParticleSystem>();
            particles.maxParticles = maxParticles;
            ParticleSystem.EmissionModule emission = particles.emission;
            emission.rateOverTime =
                maxParticles; // Установка начальной скорости эмиссии равной максимальному количеству частиц
        }

        void LateUpdate()
        {
            ConstrainParticles();
            ApplyRepulsion();
        }

        void ConstrainParticles()
        {
            ParticleSystem.Particle[] allParticles = new ParticleSystem.Particle[particles.particleCount];
            int numParticlesAlive = particles.GetParticles(allParticles);

            for (int i = 0; i < numParticlesAlive; i++)
            {
                Vector3 toCenter = allParticles[i].position - sphereCenter;
                float distance = toCenter.magnitude;

                if (distance > sphereRadius)
                {
                    // Генерация случайного направления и скорости для частицы
                    Vector3 randomDirection = Random.insideUnitSphere;
                    float randomSpeed = Random.Range(5f, 10f);
                    allParticles[i].velocity = randomDirection * randomSpeed;
                }
            }

            particles.SetParticles(allParticles, numParticlesAlive);
        }

        void ApplyRepulsion()
        {
            ParticleSystem.Particle[] allParticles = new ParticleSystem.Particle[particles.particleCount];
            int numParticlesAlive = particles.GetParticles(allParticles);

            for (int i = 0; i < numParticlesAlive; i++)
            {
                Vector3 toCenter = allParticles[i].position - sphereCenter;
                float distance = toCenter.magnitude;

                if (distance > sphereRadius - 1.0f)
                {
                    allParticles[i].velocity -= toCenter.normalized * repulsionForce;
                }
            }

            particles.SetParticles(allParticles, numParticlesAlive);
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(sphereCenter, sphereRadius);
        }
    }
}