using UnityEngine;

namespace ParticlessControll
{
    [RequireComponent(typeof(ParticleSystem))]
    public class ConstrainParticlesToSphere : MonoBehaviour
    {
        [SerializeField] private Vector3 _sphereCenter = Vector3.zero;
        [SerializeField] private float _sphereRadius = 5.0f;
        [SerializeField] private float _repulsionForce = 1.0f;
        [SerializeField] private int _maxParticles = 1000;

        private ParticleSystem _particles;

        private void Start()
        {
            _particles = GetComponent<ParticleSystem>();
            _particles.maxParticles = _maxParticles;
            ParticleSystem.EmissionModule emission = _particles.emission;
            emission.rateOverTime =
                _maxParticles;
        }

        private void LateUpdate()
        {
            ConstrainParticles();
            ApplyRepulsion();
        }

        private void ConstrainParticles()
        {
            ParticleSystem.Particle[] allParticles = new ParticleSystem.Particle[_particles.particleCount];
            int numParticlesAlive = _particles.GetParticles(allParticles);

            for (int i = 0; i < numParticlesAlive; i++)
            {
                Vector3 toCenter = allParticles[i].position - _sphereCenter;
                float distance = toCenter.magnitude;

                if (distance > _sphereRadius)
                {
                    Vector3 randomDirection = Random.insideUnitSphere;
                    float randomSpeed = Random.Range(5f, 10f);
                    allParticles[i].velocity = randomDirection * randomSpeed;
                }
            }

            _particles.SetParticles(allParticles, numParticlesAlive);
        }

        private void ApplyRepulsion()
        {
            ParticleSystem.Particle[] allParticles = new ParticleSystem.Particle[_particles.particleCount];
            int numParticlesAlive = _particles.GetParticles(allParticles);

            for (int i = 0; i < numParticlesAlive; i++)
            {
                Vector3 toCenter = allParticles[i].position - _sphereCenter;
                float distance = toCenter.magnitude;

                if (distance > _sphereRadius - 1.0f)
                {
                    allParticles[i].velocity -= toCenter.normalized * _repulsionForce;
                }
            }

            _particles.SetParticles(allParticles, numParticlesAlive);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(_sphereCenter, _sphereRadius);
        }
    }
}