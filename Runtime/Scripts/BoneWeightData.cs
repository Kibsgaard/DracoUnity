// SPDX-FileCopyrightText: 2023 Unity Technologies and the Draco for Unity authors
// SPDX-License-Identifier: Apache-2.0

using System;
using Unity.Collections;
using UnityEngine;

namespace Draco
{
    /// <summary>
    /// Draco encoded meshes might contain bone weights and indices that cannot be applied to the resulting Unity
    /// mesh right away. This class provides them and offers methods to apply them to Unity meshes.
    /// </summary>
    public sealed class BoneWeightData : IDisposable
    {
        public NativeArray<byte> bonesPerVertex;
        public NativeArray<BoneWeight1> boneWeights;

        /// <summary>
        /// Constructs an object with parameters identical to <see cref="Mesh.SetBoneWeights"/>.
        /// </summary>
        /// <param name="bonesPerVertex">Bones per vertex </param>
        /// <param name="boneWeights">Bone weights</param>
        /// <seealso cref="Mesh.SetBoneWeights"/>
        public BoneWeightData(NativeArray<byte> bonesPerVertex, NativeArray<BoneWeight1> boneWeights)
        {
            this.bonesPerVertex = bonesPerVertex;
            this.boneWeights = boneWeights;
        }

        /// <summary>
        /// Applies the bone weights and indices on a Unity mesh.
        /// </summary>
        /// <param name="mesh">The mesh to apply the data onto.</param>
        public void ApplyOnMesh(Mesh mesh)
        {
            mesh.SetBoneWeights(bonesPerVertex, boneWeights);
        }

        /// <summary>
        /// Releases allocated resources.
        /// </summary>
        public void Dispose()
        {
            bonesPerVertex.Dispose();
            boneWeights.Dispose();
        }
    }
}
