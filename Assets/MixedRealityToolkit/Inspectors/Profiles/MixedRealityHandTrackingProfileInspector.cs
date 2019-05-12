﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.﻿

using Microsoft.MixedReality.Toolkit.Editor;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities.Editor;
using UnityEditor;
using UnityEngine;

namespace Microsoft.MixedReality.Toolkit.Inspectors
{
    [CustomEditor(typeof(MixedRealityHandTrackingProfile))]
    public class MixedRealityHandTrackingProfileInspector : BaseMixedRealityToolkitConfigurationProfileInspector
    {
        private SerializedProperty jointPrefab;
        private SerializedProperty palmPrefab;
        private SerializedProperty fingertipPrefab;
        private SerializedProperty handMeshPrefab;
        private SerializedProperty enableHandMeshVisualization;
        private SerializedProperty enableHandJointVisualization;

        private const string ProfileTitle = "Hand Tracking Settings";
        private const string ProfileDescription = "Use this for platform-specific hand tracking settings.";

        protected override void OnEnable()
        {
            base.OnEnable();

            if (!MixedRealityInspectorUtility.CheckMixedRealityConfigured(false)) { return; }

            jointPrefab = serializedObject.FindProperty("jointPrefab");
            fingertipPrefab = serializedObject.FindProperty("fingertipPrefab");
            palmPrefab = serializedObject.FindProperty("palmPrefab");
            handMeshPrefab = serializedObject.FindProperty("handMeshPrefab");
            enableHandMeshVisualization = serializedObject.FindProperty("enableHandMeshVisualization");
            enableHandJointVisualization = serializedObject.FindProperty("enableHandJointVisualization");
        }

        public override void OnInspectorGUI()
        {
            if (!RenderProfileHeader(ProfileTitle, ProfileDescription, BackProfileType.Input))
            {
                return;
            }

            GUI.enabled = !CheckProfileLock((BaseMixedRealityProfile)target);
            serializedObject.Update();

            EditorGUILayout.LabelField("General settings", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(jointPrefab);
            EditorGUILayout.PropertyField(palmPrefab);
            EditorGUILayout.PropertyField(fingertipPrefab);
            EditorGUILayout.PropertyField(handMeshPrefab);
            EditorGUILayout.PropertyField(enableHandMeshVisualization);
            EditorGUILayout.PropertyField(enableHandJointVisualization);

            serializedObject.ApplyModifiedProperties();
            GUI.enabled = true;
        }
    }
}
