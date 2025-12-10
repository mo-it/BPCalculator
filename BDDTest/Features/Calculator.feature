Feature: Blood Pressure Category Calculation
  In order to classify blood pressure readings correctly
  As a health system
  I want to determine the BP category based on systolic and diastolic values

  @HighBP
  Scenario Outline: High Blood Pressure
    Given a systolic value of <Systolic>
    And a diastolic value of <Diastolic>
    When the blood pressure category is calculated
    Then the result should be "High"

    Examples:
      | Systolic | Diastolic |
      | 140      | 70        |
      | 120      | 90        |
      | 160      | 95        |

  @PreHighBP
  Scenario Outline: Pre-High Blood Pressure
    Given a systolic value of <Systolic>
    And a diastolic value of <Diastolic>
    When the blood pressure category is calculated
    Then the result should be "PreHigh"

    Examples:
      | Systolic | Diastolic |
      | 130      | 70        |
      | 125      | 85        |
      | 119      | 82        |

  @IdealBP
  Scenario Outline: Ideal Blood Pressure
    Given a systolic value of <Systolic>
    And a diastolic value of <Diastolic>
    When the blood pressure category is calculated
    Then the result should be "Ideal"

    Examples:
      | Systolic | Diastolic |
      | 100      | 70        |
      | 118      | 65        |
      | 90       | 60        |

  @LowBP
  Scenario Outline: Low Blood Pressure
    Given a systolic value of <Systolic>
    And a diastolic value of <Diastolic>
    When the blood pressure category is calculated
    Then the result should be "Low"

    Examples:
      | Systolic | Diastolic |
      | 85       | 55        |
      | 75       | 45        |
      | 89       | 59        |

  @OutOfRange
  Scenario Outline: Out-of-range Values
    Given a systolic value of <Systolic>
    And a diastolic value of <Diastolic>
    When the blood pressure category is retrieved
    Then an out of range exception should be thrown

    Examples:
      | Systolic | Diastolic |
      | 60       | 50        |
      | 200      | 80        |
      | 120      | 30        |
      | 120      | 150       |
