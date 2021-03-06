﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Nav Mesh - Not using

    public class BarrelAI : MonoBehaviour
    {
        public Transform target;

        private NavMeshAgent nav;

        void Awake()
        {
            nav = GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        void Update()
        {
            // IF target != null
            if (target != null)
            {
                // Set destination to target's position
                nav.SetDestination(target.position);
            }
        }
    }