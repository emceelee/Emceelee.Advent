using Emceelee.Advent.Transforms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emceelee.Advent.Tests
{
    [TestClass]
    public class TransformTests
    {
        #region TransformBase
        [TestMethod]
        [TestCategory("TransformBase")]
        public void TransformBase_GetAdjacentCount_All()
        {
            var transform = new SeepSiliconTransform();

            var map = new char[3,3]{ 
                { '0', '0', '0' },
                { '0', '0', '0' },
                { '0', '0', '0' } };

            var result = transform.GetAdjacentCount(map, 1, 1, '0');

            Assert.AreEqual(8, result);
        }

        [TestMethod]
        [TestCategory("TransformBase")]
        public void TransformBase_GetAdjacentCount_None()
        {
            var transform = new SeepSiliconTransform();

            var map = new char[3, 3]{
                { '0', '0', '0' },
                { '0', '0', '0' },
                { '0', '0', '0' } };

            var result = transform.GetAdjacentCount(map, 1, 1, '1');

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [TestCategory("TransformBase")]
        public void TransformBase_GetAdjacentCount_Mix()
        {
            var transform = new SeepSiliconTransform();

            var map = new char[3, 3]{
                { '0', '1', '0' },
                { '1', '0', '1' },
                { '0', '1', '0' } };

            var result = transform.GetAdjacentCount(map, 1, 1, '1');

            Assert.AreEqual(4, result);
        }

        [TestMethod]
        [TestCategory("TransformBase")]
        public void TransformBase_GetAdjacentCount_Corner1()
        {
            var transform = new SeepSiliconTransform();

            var map = new char[3, 3]{
                { '0', '0', '0' },
                { '0', '0', '0' },
                { '0', '0', '0' } };

            var result = transform.GetAdjacentCount(map, 0, 0, '0');

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        [TestCategory("TransformBase")]
        public void TransformBase_GetAdjacentCount_Corner2()
        {
            var transform = new SeepSiliconTransform();

            var map = new char[3, 3]{
                { '0', '0', '0' },
                { '0', '0', '0' },
                { '0', '0', '0' } };

            var result = transform.GetAdjacentCount(map, 0, 2, '0');

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        [TestCategory("TransformBase")]
        public void TransformBase_GetAdjacentCount_Corner3()
        {
            var transform = new SeepSiliconTransform();

            var map = new char[3, 3]{
                { '0', '0', '0' },
                { '0', '0', '0' },
                { '0', '0', '0' } };

            var result = transform.GetAdjacentCount(map, 2, 0, '0');

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        [TestCategory("TransformBase")]
        public void TransformBase_GetAdjacentCount_Corner4()
        {
            var transform = new SeepSiliconTransform();

            var map = new char[3, 3]{
                { '0', '0', '0' },
                { '0', '0', '0' },
                { '0', '0', '0' } };

            var result = transform.GetAdjacentCount(map, 2, 2, '0');

            Assert.AreEqual(3, result);
        }
        #endregion

        #region SeepSiliconTransform

        [TestMethod]
        [TestCategory("SeepSiliconTransform")]
        public void SeepSiliconTransform_ApplyTransform_Success()
        {
            var transform = new SeepSiliconTransform();

            var map = new char[3, 3]{
                { '.', '$', '.' },
                { '.', '.', '$' },
                { '$', '.', '.' } };

            var result = transform.ApplyTransform(map, 1, 1, out char next);

            Assert.IsTrue(result);
            Assert.AreEqual(Constants22_18.Silicon, next);
            Assert.AreEqual(1, transform.SuccessCount);
        }

        [TestMethod]
        [TestCategory("SeepSiliconTransform")]
        public void SeepSiliconTransform_ApplyTransform_Fail()
        {
            var transform = new SeepSiliconTransform();

            var map = new char[3, 3]{
                { '.', '$', '.' },
                { '.', '.', '$' },
                { '.', '.', '.' } };

            var result = transform.ApplyTransform(map, 1, 1, out char next);

            Assert.IsFalse(result);
            Assert.AreEqual(Constants22_18.Empty, next);
            Assert.AreEqual(0, transform.SuccessCount);
        }

        [TestMethod]
        [TestCategory("SeepSiliconTransform")]
        public void SeepSiliconTransform_ApplyTransform_Invalid()
        {
            var transform = new SeepSiliconTransform();

            var map = new char[3, 3]{
                { '.', '$', '.' },
                { '.', '$', '$' },
                { '$', '.', '.' } };

            var result = transform.ApplyTransform(map, 1, 1, out char next);

            Assert.IsFalse(result);
            Assert.AreEqual(Constants22_18.Silicon, next);
            Assert.AreEqual(0, transform.SuccessCount);
        }
        #endregion

        #region BuildMineTransform

        [TestMethod]
        [TestCategory("BuildMineTransform")]
        public void BuildMineTransform_ApplyTransform_Success()
        {
            var transform = new BuildMineTransform();

            var map = new char[3, 3]{
                { '.', '#', '.' },
                { '.', '$', '#' },
                { '#', '.', '.' } };

            var result = transform.ApplyTransform(map, 1, 1, out char next);

            Assert.IsTrue(result);
            Assert.AreEqual(Constants22_18.Mine, next);
            Assert.AreEqual(1, transform.SuccessCount);
        }

        [TestMethod]
        [TestCategory("BuildMineTransform")]
        public void BuildMineTransform_ApplyTransform_Fail()
        {
            var transform = new BuildMineTransform();

            var map = new char[3, 3]{
                { '.', '#', '.' },
                { '.', '$', '#' },
                { '.', '.', '.' } };

            var result = transform.ApplyTransform(map, 1, 1, out char next);

            Assert.IsFalse(result);
            Assert.AreEqual(Constants22_18.Silicon, next);
            Assert.AreEqual(0, transform.SuccessCount);
        }

        [TestMethod]
        [TestCategory("BuildMineTransform")]
        public void BuildMineTransform_ApplyTransform_Invalid()
        {
            var transform = new BuildMineTransform();

            var map = new char[3, 3]{
                { '.', '#', '.' },
                { '.', '#', '#' },
                { '#', '.', '.' } };

            var result = transform.ApplyTransform(map, 1, 1, out char next);

            Assert.IsFalse(result);
            Assert.AreEqual(Constants22_18.Mine, next);
            Assert.AreEqual(0, transform.SuccessCount);
        }
        #endregion

        #region DestroyMineTransform

        [TestMethod]
        [TestCategory("DestroyMineTransform")]
        public void DestroyMineTransform_ApplyTransform_Success1()
        {
            var transform = new DestroyMineTransform();

            var map = new char[3, 3]{
                { '.', '#', '.' },
                { '.', '#', '.' },
                { '.', '.', '.' } };

            var result = transform.ApplyTransform(map, 1, 1, out char next);

            Assert.IsTrue(result);
            Assert.AreEqual(Constants22_18.Empty, next);
            Assert.AreEqual(1, transform.SuccessCount);
        }

        [TestMethod]
        [TestCategory("DestroyMineTransform")]
        public void DestroyMineTransform_ApplyTransform_Success2()
        {
            var transform = new DestroyMineTransform();

            var map = new char[3, 3]{
                { '.', '$', '.' },
                { '.', '#', '.' },
                { '.', '.', '.' } };

            var result = transform.ApplyTransform(map, 1, 1, out char next);

            Assert.IsTrue(result);
            Assert.AreEqual(Constants22_18.Empty, next);
            Assert.AreEqual(1, transform.SuccessCount);
        }

        [TestMethod]
        [TestCategory("DestroyMineTransform")]
        public void DestroyMineTransform_ApplyTransform_Fail()
        {
            var transform = new DestroyMineTransform();

            var map = new char[3, 3]{
                { '.', '#', '.' },
                { '.', '#', '$' },
                { '.', '.', '.' } };

            var result = transform.ApplyTransform(map, 1, 1, out char next);

            Assert.IsFalse(result);
            Assert.AreEqual(Constants22_18.Mine, next);
            Assert.AreEqual(0, transform.SuccessCount);
        }

        [TestMethod]
        [TestCategory("DestroyMineTransform")]
        public void DestroyMineTransform_ApplyTransform_Invalid()
        {
            var transform = new DestroyMineTransform();

            var map = new char[3, 3]{
                { '.', '#', '.' },
                { '.', '.', '.' },
                { '.', '.', '.' } };

            var result = transform.ApplyTransform(map, 1, 1, out char next);

            Assert.IsFalse(result);
            Assert.AreEqual(Constants22_18.Empty, next);
            Assert.AreEqual(0, transform.SuccessCount);
        }
        #endregion

        #region SpreadMuncherTransform

        [TestMethod]
        [TestCategory("SpreadMuncherTransform")]
        public void SpreadMuncherTransform_ApplyTransform_Success()
        {
            var transform = new SpreadMuncherTransform();

            var map = new char[3, 3]{
                { '.', '@', '.' },
                { '.', '$', '.' },
                { '.', '.', '.' } };

            var result = transform.ApplyTransform(map, 1, 1, out char next);

            Assert.IsTrue(result);
            Assert.AreEqual(Constants22_18.Muncher, next);
            Assert.AreEqual(1, transform.SuccessCount);
        }

        [TestMethod]
        [TestCategory("SpreadMuncherTransform")]
        public void SpreadMuncherTransform_ApplyTransform_Fail()
        {
            var transform = new SpreadMuncherTransform();

            var map = new char[3, 3]{
                { '.', '.', '.' },
                { '.', '$', '.' },
                { '.', '.', '.' } };

            var result = transform.ApplyTransform(map, 1, 1, out char next);

            Assert.IsFalse(result);
            Assert.AreEqual(Constants22_18.Silicon, next);
            Assert.AreEqual(0, transform.SuccessCount);
        }

        [TestMethod]
        [TestCategory("SpreadMuncherTransform")]
        public void SpreadMuncherTransform_ApplyTransform_Invalid()
        {
            var transform = new SpreadMuncherTransform();

            var map = new char[3, 3]{
                { '.', '@', '.' },
                { '.', '#', '.' },
                { '.', '.', '.' } };

            var result = transform.ApplyTransform(map, 1, 1, out char next);

            Assert.IsFalse(result);
            Assert.AreEqual(Constants22_18.Mine, next);
            Assert.AreEqual(0, transform.SuccessCount);
        }
        #endregion

        #region StarveMuncherTransform

        [TestMethod]
        [TestCategory("StarveMuncherTransform")]
        public void StarveMuncherTransform_ApplyTransform_Success()
        {
            var transform = new StarveMuncherTransform();

            var map = new char[3, 3]{
                { '.', '#', '.' },
                { '.', '@', '.' },
                { '.', '.', '.' } };

            var result = transform.ApplyTransform(map, 1, 1, out char next);

            Assert.IsTrue(result);
            Assert.AreEqual(Constants22_18.Empty, next);
            Assert.AreEqual(1, transform.SuccessCount);
        }

        [TestMethod]
        [TestCategory("StarveMuncherTransform")]
        public void StarveMuncherTransform_ApplyTransform_Fail()
        {
            var transform = new StarveMuncherTransform();

            var map = new char[3, 3]{
                { '.', '$', '.' },
                { '.', '@', '.' },
                { '.', '.', '.' } };

            var result = transform.ApplyTransform(map, 1, 1, out char next);

            Assert.IsFalse(result);
            Assert.AreEqual(Constants22_18.Muncher, next);
            Assert.AreEqual(0, transform.SuccessCount);
        }

        [TestMethod]
        [TestCategory("StarveMuncherTransform")]
        public void StarveMuncherTransform_ApplyTransform_Invalid()
        {
            var transform = new StarveMuncherTransform();

            var map = new char[3, 3]{
                { '.', '@', '.' },
                { '.', '$', '.' },
                { '.', '.', '.' } };

            var result = transform.ApplyTransform(map, 1, 1, out char next);

            Assert.IsFalse(result);
            Assert.AreEqual(Constants22_18.Silicon, next);
            Assert.AreEqual(0, transform.SuccessCount);
        }
        #endregion

        #region AggregateTransform

        [TestMethod]
        [TestCategory("AggregateTransform")]
        public void AggregateTransform_ApplyTransform_Success_Mine()
        {
            var transform = new AggregateTransform<char>();
            var transform1 = new BuildMineTransform();
            transform.AddTransform(transform1);
            var transform2 = new SpreadMuncherTransform();
            transform.AddTransform(transform2);


            var map = new char[3, 3]{
                { '.', '#', '.' },
                { '.', '$', '#' },
                { '#', '@', '.' } };

            var result = transform.ApplyTransform(map, 1, 1, out char next);

            Assert.IsTrue(result);
            Assert.AreEqual(Constants22_18.Mine, next);
            Assert.AreEqual(1, transform1.SuccessCount);
            Assert.AreEqual(0, transform2.SuccessCount);
        }

        [TestMethod]
        [TestCategory("AggregateTransform")]
        public void AggregateTransform_ApplyTransform_Success_Muncher()
        {
            var transform = new AggregateTransform<char>();
            var transform1 = new BuildMineTransform();
            transform.AddTransform(transform1);
            var transform2 = new SpreadMuncherTransform();
            transform.AddTransform(transform2);

            var map = new char[3, 3]{
                { '.', '.', '.' },
                { '.', '$', '#' },
                { '#', '@', '.' } };

            var result = transform.ApplyTransform(map, 1, 1, out char next);

            Assert.IsTrue(result);
            Assert.AreEqual(Constants22_18.Muncher, next);
            Assert.AreEqual(0, transform1.SuccessCount);
            Assert.AreEqual(1, transform2.SuccessCount);
        }

        [TestMethod]
        [TestCategory("AggregateTransform")]
        public void AggregateTransform_ApplyTransform_Fail()
        {
            var transform = new AggregateTransform<char>();
            var transform1 = new BuildMineTransform();
            transform.AddTransform(transform1);
            var transform2 = new SpreadMuncherTransform();
            transform.AddTransform(transform2);

            var map = new char[3, 3]{
                { '.', '#', '.' },
                { '.', '$', '#' },
                { '.', '.', '.' } };

            var result = transform.ApplyTransform(map, 1, 1, out char next);

            Assert.IsFalse(result);
            Assert.AreEqual(Constants22_18.Silicon, next);
            Assert.AreEqual(0, transform1.SuccessCount);
            Assert.AreEqual(0, transform2.SuccessCount);
        }

        [TestMethod]
        [TestCategory("AggregateTransform")]
        public void AggregateTransform_ApplyTransform_Invalid()
        {
            var transform = new AggregateTransform<char>();
            var transform1 = new BuildMineTransform();
            transform.AddTransform(transform1);
            var transform2 = new SpreadMuncherTransform();
            transform.AddTransform(transform2);

            var map = new char[3, 3]{
                { '.', '#', '.' },
                { '.', '.', '#' },
                { '#', '@', '.' } };

            var result = transform.ApplyTransform(map, 1, 1, out char next);

            Assert.IsFalse(result);
            Assert.AreEqual(Constants22_18.Empty, next);
            Assert.AreEqual(0, transform1.SuccessCount);
            Assert.AreEqual(0, transform2.SuccessCount);
        }

        [TestMethod]
        [TestCategory("AggregateTransform")]
        public void AggregateTransform_ApplyTransform_NoMunchers()
        {
            var transform = new AggregateTransform<char>();
            var transform1 = new SeepSiliconTransform();
            transform.AddTransform(transform1);
            var transform2 = new BuildMineTransform(); //count successful minings
            transform.AddTransform(transform2);
            var transform3 = new DestroyMineTransform();
            transform.AddTransform(transform3);

            var map = new char[10, 10]{
{'.', '$', '$', '$', '.', '#', '$', '$', '$', '$', },
{'.', '.', '.', '$', '.', '$', '#', '$', '.', '#', },
{'#', '.', '$', '$', '.', '.', '$', '.', '.', '.', },
{'.', '$', '.', '$', '$', '.', '$', '.', '.', '.', },
{'$', '.', '.', '.', '.', '$', '.', '$', '#', '.', },
{'$', '$', '.', '$', '$', '$', '$', '#', '.', '.', },
{'$', '$', '.', '$', '$', '$', '.', '#', '#', '.', },
{'$', '.', '.', '$', '$', '$', '#', '#', '$', '.', },
{'.', '$', '$', '.', '$', '$', '.', '.', '.', '$', },
{'$', '#', '$', '$', '$', '.', '.', '.', '.', '.', }
            };

            //1
            map = transform.ApplyTransform(map);
            var siliconCount = Utility.Count(map, Constants22_18.Silicon);
            var mineCount = Utility.Count(map, Constants22_18.Mine);
            Assert.AreEqual(1, transform2.SuccessCount);
            Assert.AreEqual(68, siliconCount);
            Assert.AreEqual(9, mineCount);
            //2
            map = transform.ApplyTransform(map);
            siliconCount = Utility.Count(map, Constants22_18.Silicon);
            mineCount = Utility.Count(map, Constants22_18.Mine);
            Assert.AreEqual(2, transform2.SuccessCount);
            Assert.AreEqual(74, siliconCount);
            Assert.AreEqual(9, mineCount);
            //3
            map = transform.ApplyTransform(map);
            siliconCount = Utility.Count(map, Constants22_18.Silicon);
            mineCount = Utility.Count(map, Constants22_18.Mine);
            Assert.AreEqual(3, transform2.SuccessCount);
            Assert.AreEqual(77, siliconCount);
            Assert.AreEqual(10, mineCount);
            //4
            map = transform.ApplyTransform(map);
            siliconCount = Utility.Count(map, Constants22_18.Silicon);
            mineCount = Utility.Count(map, Constants22_18.Mine);
            Assert.AreEqual(5, transform2.SuccessCount);
            Assert.AreEqual(77, siliconCount);
            Assert.AreEqual(11, mineCount);
            //5
            map = transform.ApplyTransform(map);
            siliconCount = Utility.Count(map, Constants22_18.Silicon);
            mineCount = Utility.Count(map, Constants22_18.Mine);
            Assert.AreEqual(8, transform2.SuccessCount);
            Assert.AreEqual(74, siliconCount);
            Assert.AreEqual(14, mineCount);
            //6
            map = transform.ApplyTransform(map);
            siliconCount = Utility.Count(map, Constants22_18.Silicon);
            mineCount = Utility.Count(map, Constants22_18.Mine);
            Assert.AreEqual(12, transform2.SuccessCount);
            Assert.AreEqual(70, siliconCount);
            Assert.AreEqual(16, mineCount);
            //7
            map = transform.ApplyTransform(map);
            siliconCount = Utility.Count(map, Constants22_18.Silicon);
            mineCount = Utility.Count(map, Constants22_18.Mine);
            Assert.AreEqual(17, transform2.SuccessCount);
            Assert.AreEqual(65, siliconCount);
            Assert.AreEqual(19, mineCount);
            //8
            map = transform.ApplyTransform(map);
            siliconCount = Utility.Count(map, Constants22_18.Silicon);
            mineCount = Utility.Count(map, Constants22_18.Mine);
            Assert.AreEqual(23, transform2.SuccessCount);
            Assert.AreEqual(59, siliconCount);
            Assert.AreEqual(21, mineCount);
            //9
            map = transform.ApplyTransform(map);
            siliconCount = Utility.Count(map, Constants22_18.Silicon);
            mineCount = Utility.Count(map, Constants22_18.Mine);
            Assert.AreEqual(31, transform2.SuccessCount);
            Assert.AreEqual(51, siliconCount);
            Assert.AreEqual(26, mineCount);
            //10
            map = transform.ApplyTransform(map);
            siliconCount = Utility.Count(map, Constants22_18.Silicon);
            mineCount = Utility.Count(map, Constants22_18.Mine);
            Assert.AreEqual(41, transform2.SuccessCount);
            Assert.AreEqual(41, siliconCount);
            Assert.AreEqual(31, mineCount);
            //11
            map = transform.ApplyTransform(map);
            siliconCount = Utility.Count(map, Constants22_18.Silicon);
            mineCount = Utility.Count(map, Constants22_18.Mine);
            Assert.AreEqual(49, transform2.SuccessCount);
            Assert.AreEqual(33, siliconCount);
            Assert.AreEqual(29, mineCount);
            //12
            map = transform.ApplyTransform(map);
            siliconCount = Utility.Count(map, Constants22_18.Silicon);
            mineCount = Utility.Count(map, Constants22_18.Mine);
            Assert.AreEqual(56, transform2.SuccessCount);
            Assert.AreEqual(26, siliconCount);
            Assert.AreEqual(25, mineCount);
        }

        [TestMethod]
        [TestCategory("AggregateTransform")]
        public void AggregateTransform_ApplyTransform_Munchers()
        {
            var transform = new AggregateTransform<char>();
            var transform1 = new SeepSiliconTransform();
            transform.AddTransform(transform1);
            var transform2 = new BuildMineTransform(); //count successful minings
            transform.AddTransform(transform2);
            var transform3 = new DestroyMineTransform();
            transform.AddTransform(transform3);
            var transform4 = new SpreadMuncherTransform();
            transform.AddTransform(transform4);
            var transform5 = new StarveMuncherTransform();
            transform.AddTransform(transform5);

            var map = new char[10, 10]{
{'.', '$', '$', '$', '.', '#', '$', '$', '$', '$', },
{'.', '.', '.', '$', '.', '$', '#', '$', '.', '#', },
{'#', '.', '$', '$', '.', '.', '$', '.', '.', '.', },
{'.', '$', '.', '$', '$', '.', '$', '.', '.', '.', },
{'$', '.', '.', '.', '@', '$', '.', '$', '#', '.', },
{'$', '$', '.', '$', '$', '$', '$', '#', '.', '.', },
{'$', '$', '.', '$', '$', '$', '.', '#', '#', '.', },
{'$', '.', '.', '$', '$', '$', '#', '#', '$', '.', },
{'.', '$', '$', '.', '$', '$', '.', '.', '.', '$', },
{'$', '#', '$', '$', '$', '.', '.', '.', '.', '.', }
            };

            //1
            map = transform.ApplyTransform(map);
            var siliconCount = Utility.Count(map, Constants22_18.Silicon);
            var muncherCount = Utility.Count(map, Constants22_18.Muncher);
            var mineCount = Utility.Count(map, Constants22_18.Mine);
            Assert.AreEqual(1, transform2.SuccessCount);
            Assert.AreEqual(61, siliconCount);
            Assert.AreEqual(7, muncherCount);
            Assert.AreEqual(9, mineCount);
            //2
            map = transform.ApplyTransform(map);
            siliconCount = Utility.Count(map, Constants22_18.Silicon);
            muncherCount = Utility.Count(map, Constants22_18.Muncher);
            mineCount = Utility.Count(map, Constants22_18.Mine);
            Assert.AreEqual(2, transform2.SuccessCount);
            Assert.AreEqual(51, siliconCount);
            Assert.AreEqual(23, muncherCount);
            Assert.AreEqual(9, mineCount);
            //3
            map = transform.ApplyTransform(map);
            siliconCount = Utility.Count(map, Constants22_18.Silicon);
            muncherCount = Utility.Count(map, Constants22_18.Muncher);
            mineCount = Utility.Count(map, Constants22_18.Mine);
            Assert.AreEqual(2, transform2.SuccessCount);
            Assert.AreEqual(36, siliconCount);
            Assert.AreEqual(34, muncherCount);
            Assert.AreEqual(8, mineCount);
            //4
            map = transform.ApplyTransform(map);
            siliconCount = Utility.Count(map, Constants22_18.Silicon);
            muncherCount = Utility.Count(map, Constants22_18.Muncher);
            mineCount = Utility.Count(map, Constants22_18.Mine);
            Assert.AreEqual(2, transform2.SuccessCount);
            Assert.AreEqual(14, siliconCount);
            Assert.AreEqual(42, muncherCount);
            Assert.AreEqual(6, mineCount);
        }

        [TestMethod]
        [TestCategory("AggregateTransform")]
        public void AggregateTransform_ApplyTransform_NoMunchers_Recursive()
        {
            var transform = new AggregateTransform<char>();
            var transform1 = new SeepSiliconTransform();
            transform.AddTransform(transform1);
            var transform2 = new BuildMineTransform(); //count successful minings
            transform.AddTransform(transform2);
            var transform3 = new DestroyMineTransform();
            transform.AddTransform(transform3);

            var map = new char[10, 10]{
{'.', '$', '$', '$', '.', '#', '$', '$', '$', '$', },
{'.', '.', '.', '$', '.', '$', '#', '$', '.', '#', },
{'#', '.', '$', '$', '.', '.', '$', '.', '.', '.', },
{'.', '$', '.', '$', '$', '.', '$', '.', '.', '.', },
{'$', '.', '.', '.', '.', '$', '.', '$', '#', '.', },
{'$', '$', '.', '$', '$', '$', '$', '#', '.', '.', },
{'$', '$', '.', '$', '$', '$', '.', '#', '#', '.', },
{'$', '.', '.', '$', '$', '$', '#', '#', '$', '.', },
{'.', '$', '$', '.', '$', '$', '.', '.', '.', '$', },
{'$', '#', '$', '$', '$', '.', '.', '.', '.', '.', }
            };
            
            map = transform.ApplyTransform(map, 12);
            var siliconCount = Utility.Count(map, Constants22_18.Silicon);
            var mineCount = Utility.Count(map, Constants22_18.Mine);
            Assert.AreEqual(56, transform2.SuccessCount);
            Assert.AreEqual(26, siliconCount);
            Assert.AreEqual(25, mineCount);
        }

        [TestMethod]
        [TestCategory("AggregateTransform")]
        public void AggregateTransform_ApplyTransform_Munchers_Recursive()
        {
            var transform = new AggregateTransform<char>();
            var transform1 = new SeepSiliconTransform();
            transform.AddTransform(transform1);
            var transform2 = new BuildMineTransform(); //count successful minings
            transform.AddTransform(transform2);
            var transform3 = new DestroyMineTransform();
            transform.AddTransform(transform3);
            var transform4 = new SpreadMuncherTransform();
            transform.AddTransform(transform4);
            var transform5 = new StarveMuncherTransform();
            transform.AddTransform(transform5);

            var map = new char[10, 10]{
{'.', '$', '$', '$', '.', '#', '$', '$', '$', '$', },
{'.', '.', '.', '$', '.', '$', '#', '$', '.', '#', },
{'#', '.', '$', '$', '.', '.', '$', '.', '.', '.', },
{'.', '$', '.', '$', '$', '.', '$', '.', '.', '.', },
{'$', '.', '.', '.', '@', '$', '.', '$', '#', '.', },
{'$', '$', '.', '$', '$', '$', '$', '#', '.', '.', },
{'$', '$', '.', '$', '$', '$', '.', '#', '#', '.', },
{'$', '.', '.', '$', '$', '$', '#', '#', '$', '.', },
{'.', '$', '$', '.', '$', '$', '.', '.', '.', '$', },
{'$', '#', '$', '$', '$', '.', '.', '.', '.', '.', }
            };
            
            map = transform.ApplyTransform(map, 4);
            var siliconCount = Utility.Count(map, Constants22_18.Silicon);
            var muncherCount = Utility.Count(map, Constants22_18.Muncher);
            var mineCount = Utility.Count(map, Constants22_18.Mine);
            Assert.AreEqual(2, transform2.SuccessCount);
            Assert.AreEqual(14, siliconCount);
            Assert.AreEqual(42, muncherCount);
            Assert.AreEqual(6, mineCount);
        }


        #endregion
    }

}
