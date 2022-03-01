﻿/*
Copyright (c) 2020 Macross Software
*/

using System;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Core.Arango.Serialization.Json
{
#nullable enable

    // TODO: Obsolete with .NET 6?
    /// <summary>
    ///     System.Text.Json EnumMember support
    /// </summary>
    public class JsonStringEnumMemberConverter : JsonConverterFactory
    {
        private readonly bool _AllowIntegerValues;
        private readonly JsonNamingPolicy? _NamingPolicy;

        /// <summary>
        ///     Initializes a new instance of the <see cref="JsonStringEnumMemberConverter" /> class.
        /// </summary>
        public JsonStringEnumMemberConverter()
            : this(null)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="JsonStringEnumMemberConverter" /> class.
        /// </summary>
        /// <param name="namingPolicy">
        ///     Optional naming policy for writing enum values.
        /// </param>
        /// <param name="allowIntegerValues">
        ///     True to allow undefined enum values. When true, if an enum value isn't
        ///     defined it will output as a number rather than a string.
        /// </param>
        public JsonStringEnumMemberConverter(JsonNamingPolicy? namingPolicy = null, bool allowIntegerValues = true)
        {
            _NamingPolicy = namingPolicy;
            _AllowIntegerValues = allowIntegerValues;
        }

        /// <inheritdoc />
        public override bool CanConvert(Type typeToConvert)
        {
            // Don't perform a typeToConvert == null check for performance. Trust our callers will be nice.
            return typeToConvert.IsEnum
                   || typeToConvert.IsGenericType && TestNullableEnum(typeToConvert).IsNullableEnum;
        }

        /// <inheritdoc />
        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var (isNullableEnum, underlyingType) = TestNullableEnum(typeToConvert);

            return isNullableEnum
                ? (JsonConverter) Activator.CreateInstance(
                    typeof(NullableEnumMemberConverter<>).MakeGenericType(underlyingType),
                    BindingFlags.Instance | BindingFlags.Public,
                    null,
                    new object?[] {_NamingPolicy, _AllowIntegerValues},
                    null)
                : (JsonConverter) Activator.CreateInstance(
                    typeof(EnumMemberConverter<>).MakeGenericType(typeToConvert),
                    BindingFlags.Instance | BindingFlags.Public,
                    null,
                    new object?[] {_NamingPolicy, _AllowIntegerValues},
                    null);
        }

        private static (bool IsNullableEnum, Type? UnderlyingType) TestNullableEnum(Type typeToConvert)
        {
            var underlyingType = Nullable.GetUnderlyingType(typeToConvert);

            return (underlyingType?.IsEnum ?? false, underlyingType);
        }

#pragma warning disable CA1812 // Remove class never instantiated
        private class EnumMemberConverter<TEnum> : JsonConverter<TEnum>
            where TEnum : struct, Enum
#pragma warning restore CA1812 // Remove class never instantiated
        {
            private readonly JsonStringEnumMemberConverterHelper<TEnum> _JsonStringEnumMemberConverterHelper;

            public EnumMemberConverter(JsonNamingPolicy? namingPolicy, bool allowIntegerValues)
            {
                _JsonStringEnumMemberConverterHelper =
                    new JsonStringEnumMemberConverterHelper<TEnum>(namingPolicy, allowIntegerValues);
            }

            public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                return _JsonStringEnumMemberConverterHelper.Read(ref reader);
            }

            public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
            {
                _JsonStringEnumMemberConverterHelper.Write(writer, value);
            }
        }

#pragma warning disable CA1812 // Remove class never instantiated
        private class NullableEnumMemberConverter<TEnum> : JsonConverter<TEnum?>
            where TEnum : struct, Enum
#pragma warning restore CA1812 // Remove class never instantiated
        {
            private readonly JsonStringEnumMemberConverterHelper<TEnum> _JsonStringEnumMemberConverterHelper;

            public NullableEnumMemberConverter(JsonNamingPolicy? namingPolicy, bool allowIntegerValues)
            {
                _JsonStringEnumMemberConverterHelper =
                    new JsonStringEnumMemberConverterHelper<TEnum>(namingPolicy, allowIntegerValues);
            }

            public override TEnum? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                return _JsonStringEnumMemberConverterHelper.Read(ref reader);
            }

            public override void Write(Utf8JsonWriter writer, TEnum? value, JsonSerializerOptions options)
            {
                _JsonStringEnumMemberConverterHelper.Write(writer, value!.Value);
            }
        }
    }

#nullable restore
}