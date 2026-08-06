using Italcom.AgentOrchestrator.Infrastructure.Configuration;

namespace Italcom.AgentOrchestrator.UnitTests.Configuration;

public sealed class SecretRedactorTests
{
    [Theory]
    [InlineData("ApiKey", "sk-or-v1-secret123", "sk-o***")]
    [InlineData("api_key", "secret-value", "secr***")]
    [InlineData("api-key", "my-password", "my-p***")]
    [InlineData("Key", "short", "***")]
    [InlineData("Password", "1234", "***")]
    [InlineData("Secret", "123", "***")]
    [InlineData("Token", "abcdef", "abcd***")]
    [InlineData("ConnectionString", "Host=localhost;Password=secret;", "Host***")]
    [InlineData("Credential", "supersecret", "supe***")]
    [InlineData("Pwd", "test1234", "test***")]
    public void Redact_truncates_sensitive_values(string key, string value, string expected)
    {
        var result = SecretRedactor.Redact("TestSection", key, value);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Redact_returns_value_as_is_for_non_sensitive_keys()
    {
        var result = SecretRedactor.Redact("TestSection", "BaseUrl", "http://example.com/");
        Assert.Equal("http://example.com/", result);
    }

    [Fact]
    public void Redact_returns_value_as_is_for_non_sensitive_keys_even_with_partial_match()
    {
        var result = SecretRedactor.Redact("TestSection", "MyKeychain", "full-value");
        Assert.Equal("full-value", result);
    }

    [Fact]
    public void Redact_returns_empty_string_when_value_is_null()
    {
        var result = SecretRedactor.Redact("TestSection", "ApiKey", null);
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void Redact_returns_empty_string_when_value_is_empty()
    {
        var result = SecretRedactor.Redact("TestSection", "ApiKey", "");
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void Redact_returns_three_asterisks_when_value_length_is_four_or_less()
    {
        var result = SecretRedactor.Redact("TestSection", "Secret", "ab");
        Assert.Equal("***", result);
    }

    [Fact]
    public void Redact_is_case_insensitive()
    {
        var resultLower = SecretRedactor.Redact("TestSection", "apikey", "secret-value");
        var resultUpper = SecretRedactor.Redact("TestSection", "APIKEY", "secret-value");
        var resultMixed = SecretRedactor.Redact("TestSection", "ApiKey", "secret-value");

        Assert.Equal(resultLower, resultUpper);
        Assert.Equal(resultLower, resultMixed);
    }
}
