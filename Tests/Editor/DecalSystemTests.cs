using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using kTools.Pooling;

namespace kTools.Decals.Editor.Tests
{
    public sealed class DecalSystemTests
    {
#region Fields
        DecalData m_DecalData;
        DecalData m_DecalDataPooled;
#endregion

#region Properties
        DecalData decalData
        {
            get
            {
                if(m_DecalData == null)
                    m_DecalData = Resources.Load("TestDecal") as DecalData;
                return m_DecalData;
            }
        }

        DecalData decalDataPooled
        {
            get
            {
                if(m_DecalDataPooled == null)
                    m_DecalDataPooled = Resources.Load("TestDecalPooled") as DecalData;
                return m_DecalDataPooled;
            }
        }
#endregion

#region Setup
        [SetUp]
        public void SetUp()
        {
            // Ensure Pools are set up
            if(!KinkDecalSystem.HasDecalPool(decalDataPooled))
            {
                KinkDecalSystem.CreateDecalPool(decalDataPooled);
            }
        }
#endregion

#region Tests
        [Test]
        public void CanCreateDecalPool()
        {
            // Execution
            var hasPool = KinkDecalSystem.HasDecalPool(decalDataPooled);

            // Result
            Assert.IsTrue(hasPool);
            LogAssert.NoUnexpectedReceived();
        }
        
        [Test]
        public void CanDestroyDecalPool()
        {
            // Execution
            KinkDecalSystem.DestroyDecalPool(decalDataPooled);
            var hasPool = KinkDecalSystem.HasDecalPool(decalDataPooled);

            // Result
            Assert.IsFalse(hasPool);
            LogAssert.NoUnexpectedReceived();
        }

        [Test]
        public void CanGetDecal()
        {
            // Execution
            var decal = KinkDecalSystem.GetDecal(decalData);
            var hasPool = PoolingSystem.HasPool<DecalData>(decalData);

            // Result
            Assert.IsFalse(hasPool);
            Assert.IsNotNull(decal);
            LogAssert.NoUnexpectedReceived();
        }

        [Test]
        public void CanGetDecalPooled()
        {
            // Execution
            var hasPool = KinkDecalSystem.HasDecalPool(decalDataPooled);
            var decal = KinkDecalSystem.GetDecal(decalDataPooled);

            // Result
            Assert.IsTrue(hasPool);
            Assert.IsNotNull(decal);
            LogAssert.NoUnexpectedReceived();
        }

        [Test]
        public void CanRemoveDecal()
        {
            // Execution
            var decal = KinkDecalSystem.GetDecal(decalData);
            var obj = decal.gameObject;
            KinkDecalSystem.RemoveDecal(decal);

            // Result
            LogAssert.NoUnexpectedReceived();
        }

        [Test]
        public void CanRemoveDecalPooled()
        {
            // Execution
            var decal = KinkDecalSystem.GetDecal(decalDataPooled);
            KinkDecalSystem.RemoveDecal(decal);
            var isRemoved = !decal.gameObject.activeSelf;

            // Result
            Assert.IsTrue(isRemoved);
            Assert.IsNotNull(decal);
            LogAssert.NoUnexpectedReceived();
        }
#endregion
    }
}
