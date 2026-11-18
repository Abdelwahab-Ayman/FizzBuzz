#### Akvelon Coding Task 
#### FizzBuzz
#### Constraints & Validation

- **Non-null input:** The input string cannot be `null` (`ArgumentNullException`).
- **Length restriction:** The input string length must satisfy $7 \le |s| \le 100$ characters (`ArgumentException`).



#### Project Structure

```text
FizzBuzz/
├── FizzBuzz/
│   ├── FizzBuzzDetector.cs      # Core FizzBuzz algorithm and token parsing
│   ├── FizzBuzzResult.cs        # Output DTO containing transformed text & replacement count
│   └── FizzBuzz.csproj          # Class library target (.NET 10.0)
└── FizzBuzzTests/
    ├── FizzBuzzDetectorTests.cs # Unit test suite using xUnit
    └── FizzBuzzTests.csproj     # Test project target (.NET 10.0)
```
#### API Reference

##### `FizzBuzzDetector`

```csharp
namespace FizzBuzz
{
    public class FizzBuzzDetector
    {
        public FizzBuzzResult getOverlappings(string input);
    }
}
```

#### Parameters
- `input` (`string`): The text string to parse and transform (7 to 100 characters).

#### Returns
- `FizzBuzzResult`: An object containing:
  - `Output` (`string`): The transformed text with substitutions applied.
  - `Count` (`int`): The total number of words that were replaced.

#### Building & Running Tests

### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download) (.NET 10.0 or compatible)

##### Build the Solution
```bash
dotnet build
```

##### Run Tests
```bash
dotnet test
```
