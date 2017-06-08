﻿using System.Collections.Generic;
using System.Reflection;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using Yutai.ArcGIS.Common.Editor.Helpers;
using Yutai.ArcGIS.Common.Helpers;
using Yutai.Plugins.Interfaces;

namespace Yutai.ArcGIS.Common.Editor
{
	public class PointSnapper : IPointSnapper
	{
		public IMap Map
		{
			get;
			set;
		}

		public IPoint TangentInputPoint
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public PointSnapper()
		{
		}

		public int CacheShapes(IGeometryBag igeometryBag_0, string string_0)
		{
			return 0;
		}

		public void ClearCache()
		{
		}

		public void ExcludedLayers(ref ISet iset_0)
		{
		}

		public ISnappingResult FullSnap(IPoint ipoint_0)
		{
			SnappingResult snappingResult = new SnappingResult()
			{
				X = ipoint_0.X,
				Y = ipoint_0.Y
			};
			return snappingResult;
		}

		private IPoint method_0(IPointCollection ipointCollection_0, IPoint ipoint_0, double double_0)
		{
			IPoint pointClass = new ESRI.ArcGIS.Geometry.Point();
			double num = -100;
			for (int i = 0; i < ipointCollection_0.PointCount; i++)
			{
				IPoint point = ipointCollection_0.Point[i];
				double num1 = CommonHelper.distance(ipoint_0, point);
				if (num1 <= double_0)
				{
					if (num < 0)
					{
						num = num1;
						pointClass.X = point.X;
						pointClass.Y = point.Y;
						pointClass.Z = point.Z;
					}
					else if (num > num1)
					{
						num = num1;
						pointClass.X = point.X;
						pointClass.Y = point.Y;
						pointClass.Z = point.Z;
					}
				}
			}
			return pointClass;
		}

		private string method_1(IFeature ifeature_0)
		{
			string aliasName = ifeature_0.Class.AliasName;
			UID uIDClass = new UID()
			{
				Value = "{6CA416B1-E160-11D2-9F4E-00C04F6BC78E}"
			};
			IEnumLayer layers = this.Map.Layers[uIDClass, true];
			layers.Reset();
			ILayer layer = layers.Next();
			while (true)
			{
				if (layer == null)
				{
					break;
				}
				else if (!(layer is IFeatureLayer) || (layer as IFeatureLayer).FeatureClass != ifeature_0.Class)
				{
					layer = layers.Next();
				}
				else
				{
					aliasName = layer.Name;
					break;
				}
			}
			return aliasName;
		}

		private IPoint method_2(IPoint ipoint_0, IFeatureCache2 ifeatureCache2_0, double double_0)
		{
			IPoint shape;
			double num;
			double num1 = -10;
			IFeature feature = null;
			IPoint shapeCopy = null;
			for (int i = 0; i < ifeatureCache2_0.Count; i++)
			{
				IFeature feature1 = ifeatureCache2_0.Feature[i];
				if (feature1.Shape.GeometryType == esriGeometryType.esriGeometryPoint)
				{
					shape = feature1.Shape as IPoint;
					num = CommonHelper.distance(ipoint_0, shape);
					if (num <= double_0)
					{
						if (num1 < 0)
						{
							num1 = num;
							shapeCopy = feature1.ShapeCopy as IPoint;
							feature = feature1;
						}
						else if (num1 > num)
						{
							num1 = num;
							shapeCopy.X = shape.X;
							shapeCopy.Y = shape.Y;
							shapeCopy.Z = shape.Z;
							feature = feature1;
						}
					}
				}
				else if (feature1.Shape.GeometryType == esriGeometryType.esriGeometryMultipoint)
				{
					shape = this.method_0(feature1.Shape as IPointCollection, ipoint_0, double_0);
					num = CommonHelper.distance(ipoint_0, shape);
					if (num <= double_0)
					{
						if (num1 < 0)
						{
							num1 = num;
							shapeCopy = shape;
							feature = feature1;
						}
						else if (num1 > num)
						{
							num1 = num;
							shapeCopy.X = shape.X;
							shapeCopy.Y = shape.Y;
							shapeCopy.Z = shape.Z;
							feature = feature1;
						}
					}
				}
			}
			if (feature != null)
			{
				string str = string.Concat(this.method_1(feature), ":点");
				ApplicationRef.AppContext.SetToolTip(str);
			}
			return shapeCopy;
		}

		private IPoint method_3(IPoint ipoint_0, IFeatureCache2 ifeatureCache2_0, double double_0)
		{
			double num = 0;
			int num1 = 0;
			int num2 = 0;
			bool flag = true;
			double num3 = -10;
			IPoint x = null;
			IFeature feature = null;
			for (int i = 0; i < ifeatureCache2_0.Count; i++)
			{
				IFeature feature1 = ifeatureCache2_0.Feature[i];
				if (feature1.Shape.GeometryType == esriGeometryType.esriGeometryPolyline)
				{
					IPoint pointClass = new ESRI.ArcGIS.Geometry.Point();
					if (((IHitTest)feature1.Shape).HitTest(ipoint_0, double_0, esriGeometryHitPartType.esriGeometryPartEndpoint, pointClass, ref num, ref num1, ref num2, ref flag) && num <= double_0)
					{
						if (num3 < 0)
						{
							num3 = num;
							x = pointClass;
							feature = feature1;
						}
						else if (num3 > num)
						{
							num3 = num;
							x.X = pointClass.X;
							x.Y = pointClass.Y;
							x.Z = pointClass.Z;
							feature = feature1;
						}
					}
				}
			}
			if (feature != null)
			{
				string str = string.Concat(this.method_1(feature), ":端点");
				ApplicationRef.AppContext.SetToolTip(str);
			}
			return x;
		}

		private IPoint method_4(IPoint ipoint_0, IFeatureCache2 ifeatureCache2_0, double double_0)
		{
			IFeature feature = null;
			double num = 0;
			int num1 = 0;
			int num2 = 0;
			bool flag = true;
			double num3 = -10;
			IPoint x = null;
			for (int i = 0; i < ifeatureCache2_0.Count; i++)
			{
				IFeature feature1 = ifeatureCache2_0.Feature[i];
				if ((feature1.Shape.GeometryType == esriGeometryType.esriGeometryPolyline ? true : feature1.Shape.GeometryType == esriGeometryType.esriGeometryPolygon))
				{
					IPoint pointClass = new ESRI.ArcGIS.Geometry.Point();
					if (((IHitTest)feature1.Shape).HitTest(ipoint_0, double_0, esriGeometryHitPartType.esriGeometryPartBoundary, pointClass, ref num, ref num1, ref num2, ref flag) && num <= double_0)
					{
						if (num3 < 0)
						{
							num3 = num;
							x = pointClass;
							feature = feature1;
						}
						else if (num3 > num)
						{
							num3 = num;
							x.X = pointClass.X;
							x.Y = pointClass.Y;
							x.Z = pointClass.Z;
							feature = feature1;
						}
					}
				}
			}
			if (feature != null)
			{
				string str = string.Concat(this.method_1(feature), ":边");
				ApplicationRef.AppContext.SetToolTip(str);
			}
			return x;
		}

		private IPoint method_5(IPoint ipoint_0, IFeatureCache2 ifeatureCache2_0, double double_0)
		{
			IFeature feature = null;
			double num = 0;
			int num1 = 0;
			int num2 = 0;
			bool flag = true;
			double num3 = -10;
			IPoint x = null;
			for (int i = 0; i < ifeatureCache2_0.Count; i++)
			{
				IFeature feature1 = ifeatureCache2_0.Feature[i];
				if ((feature1.Shape.GeometryType == esriGeometryType.esriGeometryPolyline ? true : feature1.Shape.GeometryType == esriGeometryType.esriGeometryPolygon))
				{
					IPoint pointClass = new ESRI.ArcGIS.Geometry.Point();
					if (((IHitTest)feature1.Shape).HitTest(ipoint_0, double_0, esriGeometryHitPartType.esriGeometryPartVertex, pointClass, ref num, ref num1, ref num2, ref flag) && num <= double_0)
					{
						if (num3 < 0)
						{
							num3 = num;
							x = pointClass;
							feature = feature1;
						}
						else if (num3 > num)
						{
							num3 = num;
							x.X = pointClass.X;
							x.Y = pointClass.Y;
							x.Z = pointClass.Z;
							feature = feature1;
						}
					}
				}
			}
			if (feature != null)
			{
				string str = string.Concat(this.method_1(feature), ":折点");
				ApplicationRef.AppContext.SetToolTip(str);
			}
			return x;
		}

		private IPoint method_6(IPoint ipoint_0, IFeatureCache2 ifeatureCache2_0, double double_0)
		{
			IFeature feature = null;
			double num = 0;
			int num1 = 0;
			int num2 = 0;
			bool flag = true;
			double num3 = -10;
			IPoint x = null;
			for (int i = 0; i < ifeatureCache2_0.Count; i++)
			{
				IFeature feature1 = ifeatureCache2_0.Feature[i];
				if ((feature1.Shape.GeometryType == esriGeometryType.esriGeometryPolyline ? true : feature1.Shape.GeometryType == esriGeometryType.esriGeometryPolygon))
				{
					IPoint pointClass = new ESRI.ArcGIS.Geometry.Point();
					if (((IHitTest)feature1.Shape).HitTest(ipoint_0, double_0, esriGeometryHitPartType.esriGeometryPartMidpoint, pointClass, ref num, ref num1, ref num2, ref flag) && num <= double_0)
					{
						if (num3 < 0)
						{
							num3 = num;
							x = pointClass;
							feature = feature1;
						}
						else if (num3 > num)
						{
							num3 = num;
							x.X = pointClass.X;
							x.Y = pointClass.Y;
							x.Z = pointClass.Z;
							feature = feature1;
						}
					}
				}
			}
			if (feature != null)
			{
				string str = string.Concat(this.method_1(feature), ":中点");
				ApplicationRef.AppContext.SetToolTip(str);
			}
			return x;
		}

		private IPoint method_7(IPoint ipoint_0, IFeatureCache2 ifeatureCache2_0, double double_0)
		{
			int i;
			IGeometry geometry;
			double num = 0;
			int num1 = 0;
			int num2 = 0;
			bool flag = true;
			IPoint point = null;
			List<IGeometry> geometries = new List<IGeometry>();
			for (i = 0; i < ifeatureCache2_0.Count; i++)
			{
				IFeature feature = ifeatureCache2_0.Feature[i];
				if ((feature.Shape.GeometryType == esriGeometryType.esriGeometryPolyline ? true : feature.Shape.GeometryType == esriGeometryType.esriGeometryPolygon))
				{
					IPoint pointClass = new ESRI.ArcGIS.Geometry.Point();
					IHitTest shape = (IHitTest)feature.Shape;
					if (shape.HitTest(ipoint_0, double_0, esriGeometryHitPartType.esriGeometryPartBoundary, pointClass, ref num, ref num1, ref num2, ref flag) && num <= double_0)
					{
						geometries.Add(shape as IGeometry);
					}
				}
			}
			IPointCollection multipointClass = new Multipoint();
			for (i = 0; i < geometries.Count; i++)
			{
				ITopologicalOperator2 item = (ITopologicalOperator2)geometries[i];
				for (int j = 0; j < geometries.Count; j++)
				{
					if (i != j)
					{
						if (geometries[i].GeometryType != geometries[j].GeometryType)
						{
							geometry = item.IntersectMultidimension(geometries[j]);
							if (geometry != null)
							{
								IGeometryCollection geometryCollection = geometry as IGeometryCollection;
								if (geometryCollection != null)
								{
									for (int k = 0; k < geometryCollection.GeometryCount; k++)
									{
										geometry = geometryCollection.Geometry[k];
										if (geometry is IPointCollection)
										{
											multipointClass.AddPointCollection((IPointCollection)geometry);
										}
										else if (geometry is IPoint)
										{
											object value = Missing.Value;
											object obj = Missing.Value;
											multipointClass.AddPoint((IPoint)geometry, ref value, ref obj);
										}
									}
								}
							}
						}
						else
						{
							geometry = item.Intersect(geometries[j], esriGeometryDimension.esriGeometry0Dimension);
							if (geometry != null)
							{
								if (geometry is IPointCollection)
								{
									multipointClass.AddPointCollection((IPointCollection)geometry);
								}
								else if (geometry is IPoint)
								{
									object value1 = Missing.Value;
									object obj1 = Missing.Value;
									multipointClass.AddPoint((IPoint)geometry, ref value1, ref obj1);
								}
							}
						}
					}
				}
			}
			IHitTest hitTest = (IHitTest)multipointClass;
			IPoint pointClass1 = new ESRI.ArcGIS.Geometry.Point();
			if (hitTest.HitTest(ipoint_0, double_0, esriGeometryHitPartType.esriGeometryPartVertex, pointClass1, ref num, ref num1, ref num2, ref flag) && num < double_0)
			{
				point = pointClass1;
			}
			if (point != null)
			{
				ApplicationRef.AppContext.SetToolTip("交点");
			}
			return point;
		}

		private IPoint method_8(IPoint ipoint_0, IFeatureCache2 ifeatureCache2_0, double double_0)
		{
			int i;
			IGeometry geometry;
			double num = 0;
			int num1 = 0;
			int num2 = 0;
			bool flag = true;
			IPoint point = null;
			List<IGeometry> geometries = new List<IGeometry>();
			for (i = 0; i < ifeatureCache2_0.Count; i++)
			{
				IFeature feature = ifeatureCache2_0.Feature[i];
				if ((feature.Shape.GeometryType == esriGeometryType.esriGeometryPolyline ? true : feature.Shape.GeometryType == esriGeometryType.esriGeometryPolygon))
				{
					IPoint pointClass = new ESRI.ArcGIS.Geometry.Point();
					IHitTest shape = (IHitTest)feature.Shape;
					if (shape.HitTest(ipoint_0, double_0, esriGeometryHitPartType.esriGeometryPartBoundary, pointClass, ref num, ref num1, ref num2, ref flag) && num <= double_0)
					{
						IGeometryCollection geometryCollection = shape as IGeometryCollection;
						if (geometryCollection != null)
						{
							ISegmentCollection segmentCollection = geometryCollection.Geometry[num1] as ISegmentCollection;
							if (segmentCollection != null)
							{
								//segmentCollection.Segment[num2] is ICircularArc;
							}
						}
					}
				}
			}
			IPointCollection multipointClass = new Multipoint();
			for (i = 0; i < geometries.Count; i++)
			{
				ITopologicalOperator2 item = (ITopologicalOperator2)geometries[i];
				for (int j = 0; j < geometries.Count; j++)
				{
					if (i != j)
					{
						if (geometries[i].GeometryType != geometries[j].GeometryType)
						{
							geometry = item.IntersectMultidimension(geometries[j]);
							if (geometry != null)
							{
								IGeometryCollection geometryCollection1 = geometry as IGeometryCollection;
								if (geometryCollection1 != null)
								{
									for (int k = 0; k < geometryCollection1.GeometryCount; k++)
									{
										geometry = geometryCollection1.Geometry[k];
										if (geometry is IPointCollection)
										{
											multipointClass.AddPointCollection((IPointCollection)geometry);
										}
										else if (geometry is IPoint)
										{
											object value = Missing.Value;
											object obj = Missing.Value;
											multipointClass.AddPoint((IPoint)geometry, ref value, ref obj);
										}
									}
								}
							}
						}
						else
						{
							geometry = item.Intersect(geometries[j], esriGeometryDimension.esriGeometry0Dimension);
							if (geometry != null)
							{
								if (geometry is IPointCollection)
								{
									multipointClass.AddPointCollection((IPointCollection)geometry);
								}
								else if (geometry is IPoint)
								{
									object value1 = Missing.Value;
									object obj1 = Missing.Value;
									multipointClass.AddPoint((IPoint)geometry, ref value1, ref obj1);
								}
							}
						}
					}
				}
			}
			IHitTest hitTest = (IHitTest)multipointClass;
			IPoint pointClass1 = new ESRI.ArcGIS.Geometry.Point();
			if (hitTest.HitTest(ipoint_0, double_0, esriGeometryHitPartType.esriGeometryPartVertex, pointClass1, ref num, ref num1, ref num2, ref flag) && num < double_0)
			{
				point = pointClass1;
			}
			return point;
		}

		private bool method_9(IPoint ipoint_0, IAppContext appContext, double double_0, out IPoint ipoint_1)
		{
			bool flag;
			IMap focusMap = appContext.MapControl.Map;
			ipoint_1 = null;
			if (appContext.Config.UseSnap)
			{
				if (appContext.Config.IsSnapSketch)
				{
					IHitTest mPPointColn = SketchToolAssist.m_pPointColn as IHitTest;
					if (mPPointColn != null)
					{
						double num = 0;
						int num1 = 0;
						int num2 = 0;
						bool flag1 = false;
						IPoint pointClass = new ESRI.ArcGIS.Geometry.Point();
						if (!mPPointColn.HitTest(ipoint_0, double_0, esriGeometryHitPartType.esriGeometryPartVertex, pointClass, ref num, ref num1, ref num2, ref flag1))
						{
							goto Label1;
						}
						ipoint_1 = pointClass;
						ApplicationRef.AppContext.SetToolTip("草图:折点");
						flag = true;
						return flag;
					}
				}
			Label1:
				UID uIDClass = new UID()
				{
					Value = "{6CA416B1-E160-11D2-9F4E-00C04F6BC78E}"
				};
				IEnumLayer layers = focusMap.Layers[uIDClass, true];
				layers.Reset();
				layers.Next();
				IFeatureCache2 featureCacheClass = new FeatureCache() as IFeatureCache2;
				featureCacheClass.Initialize(ipoint_0, double_0);
				try
				{
					featureCacheClass.AddLayers(layers, (focusMap as IActiveView).Extent);
				}
				catch
				{
				}
				if (featureCacheClass.Count != 0)
				{
					if (appContext.Config.IsSnapPoint)
					{
						ipoint_1 = this.method_2(ipoint_0, featureCacheClass, double_0);
						if (ipoint_1 == null)
						{
							goto Label2;
						}
						flag = true;
						return flag;
					}
				Label2:
					if (appContext.Config.IsSnapIntersectionPoint)
					{
						ipoint_1 = this.method_7(ipoint_0, featureCacheClass, double_0);
						if (ipoint_1 == null)
						{
							goto Label3;
						}
						flag = true;
						return flag;
					}
				Label3:
					if (appContext.Config.IsSnapEndPoint)
					{
						ipoint_1 = this.method_3(ipoint_0, featureCacheClass, double_0);
						if (ipoint_1 == null)
						{
							goto Label4;
						}
						flag = true;
						return flag;
					}
				Label4:
					if (appContext.Config.IsSnapVertexPoint)
					{
						ipoint_1 = this.method_5(ipoint_0, featureCacheClass, double_0);
						if (ipoint_1 == null)
						{
							goto Label5;
						}
						flag = true;
						return flag;
					}
				Label5:
					if (appContext.Config.IsSnapMiddlePoint)
					{
						ipoint_1 = this.method_6(ipoint_0, featureCacheClass, double_0);
						if (ipoint_1 == null)
						{
							goto Label6;
						}
						flag = true;
						return flag;
					}
				Label6:
					if (appContext.Config.IsSnapBoundary)
					{
						ipoint_1 = this.method_4(ipoint_0, featureCacheClass, double_0);
						if (ipoint_1 == null)
						{
							goto Label7;
						}
						flag = true;
						return flag;
					}
				Label7:
					flag = false;
				}
				else
				{
					flag = false;
				}
			}
			else
			{
				flag = false;
			}
			return flag;
		}

		public void RemoveCachedShapes(int int_0)
		{
		}

		public ISnappingResult Snap(IPoint ipoint_0)
		{
			ISnappingResult snappingResult;
			if (this.Map != null)
			{
				IPoint point = null;
				IAppContext application = ApplicationRef.AppContext;
				double snapTolerance = application.Config.EngineSnapEnvironment.SnapTolerance;
				if (application.Config.EngineSnapEnvironment.SnapToleranceUnits == esriEngineSnapToleranceUnits.esriEngineSnapTolerancePixels)
				{
					snapTolerance = CommonHelper.ConvertPixelsToMapUnits(application.MapControl.Map as IActiveView, snapTolerance);
				}
				if (!this.method_9(ipoint_0, application, snapTolerance, out point))
				{
					ApplicationRef.AppContext.SetToolTip("");
					snappingResult = null;
				}
				else
				{
					SnappingResult snappingResult1 = new SnappingResult()
					{
						X = point.X,
						Y = point.Y
					};
					snappingResult = snappingResult1;
				}
			}
			else
			{
				snappingResult = null;
			}
			return snappingResult;
		}

		public void UpdateCachedShapes(int int_0, IGeometryBag igeometryBag_0)
		{
		}
	}
}