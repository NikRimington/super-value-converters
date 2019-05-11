﻿using System;
using Our.Umbraco.SuperValueConverters.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.PropertyEditors;
using Umbraco.Web.PropertyEditors;
using Umbraco.Web.PublishedCache;
using Core = Umbraco.Web.PropertyEditors.ValueConverters;

namespace Our.Umbraco.SuperValueConverters.ValueConverters
{
    public class MediaPickerValueConverter : Core.MediaPickerValueConverter
    {
        public MediaPickerValueConverter(IPublishedSnapshotAccessor publishedSnapshotAccessor)
            : base(publishedSnapshotAccessor)
        {

        }

        public override Type GetPropertyValueType(PublishedPropertyType propertyType)
        {
            var pickerSettings = GetSettings(propertyType);

            return BaseValueConverter.GetPropertyValueType(propertyType, pickerSettings);
        }

        public override object ConvertIntermediateToObject(IPublishedElement owner, PublishedPropertyType propertyType, PropertyCacheLevel cacheLevel, object source, bool preview)
        {
            var value = base.ConvertIntermediateToObject(owner, propertyType, cacheLevel, source, preview);

            return BaseValueConverter.ConvertIntermediateToObject(propertyType, value);
        }

        private IPickerSettings GetSettings(PublishedPropertyType propertyType)
        {
            var configuration = propertyType.DataType.ConfigurationAs<MediaPickerConfiguration>();

            var settings = new MediaPickerSettings
            {
                AllowedDoctypes = configuration.OnlyImages ? new string[] { "images" } : new string[] { },
                MaxItems = configuration.Multiple ? 1 : 0
            };

            return settings;
        }
    }
}