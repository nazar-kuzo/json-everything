﻿using NUnit.Framework;
using static Json.Schema.DataGeneration.Tests.TestRunner;

namespace Json.Schema.DataGeneration.Tests;

internal class OneOfGenerationTests
{
	[Test]
	public void OneOfWithDifferentTypesButOneTypeIsDuplicatedForcingTheOther()
	{
		JsonSchema schema = new JsonSchemaBuilder()
			.OneOf(
				new JsonSchemaBuilder().Type(SchemaValueType.Integer),
				new JsonSchemaBuilder().Type(SchemaValueType.Integer),
				new JsonSchemaBuilder().Type(SchemaValueType.String)
			);

		Run(schema);
	}

	[Test]
	public void OneOfWithMultipleOfCannotBeMultipleOfBoth()
	{
		JsonSchema schema = new JsonSchemaBuilder()
			.Type(SchemaValueType.Integer)
			.OneOf(
				new JsonSchemaBuilder()
					.MultipleOf(2),
				new JsonSchemaBuilder()
					.MultipleOf(3)
			)
			.Minimum(0)
			.Maximum(50);

		Run(schema);
	}
}