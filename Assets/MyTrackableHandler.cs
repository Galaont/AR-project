using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class MyTrackableHandler :MonoBehaviour,
                                                ITrackableEventHandler
    {
        #region PRIVATE_MEMBER_VARIABLES
 
        private TrackableBehaviour mTrackableBehaviour;

        private bool isFirstTime = false;

        #endregion // PRIVATE_MEMBER_VARIABLES



        #region UNTIY_MONOBEHAVIOUR_METHODS
    
        void Start()
        {
            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }
        }

        #endregion // UNTIY_MONOBEHAVIOUR_METHODS



        #region PUBLIC_METHODS

        /// <summary>
        /// Implementation of the ITrackableEventHandler function called when the
        /// tracking state changes.
        /// </summary>
        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                OnTrackingFound();
            }
            else
            {
                OnTrackingLost();
            }
        }

        #endregion // PUBLIC_METHODS



        #region PRIVATE_METHODS


        private void OnTrackingFound()
        {

            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Enable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = true;
            }

            // Enable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = true;
            }

            print("MEF FOUND");
            if (isFirstTime)
            {
                isFirstTime = false;
            }
            else {
            if(GetComponentInChildren<Animator>()!=null)
                GetComponentInChildren<Animator>().SetTrigger("animate");
            GetComponentInChildren<AudioSource>().Play();
            }    
        }


        private void OnTrackingLost()
        {
        print("MEF DIDN'T FOUND");
        if (GetComponentInChildren<Animator>() != null)
        {
            GetComponentInChildren<Animator>().StopPlayback();
            GetComponentInChildren<Animator>().SetTrigger("stop");
        }
        if (GetComponentInChildren<AudioSource>() != null)
        {
            GetComponentInChildren<AudioSource>().Stop();
        }
        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
        Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

        // Disable rendering:
        foreach (Renderer component in rendererComponents)
        {
            component.enabled = false;
        }

        // Disable colliders:
        foreach (Collider component in colliderComponents)
        {
            component.enabled = false;
        }

    }

        #endregion // PRIVATE_METHODS
    }

