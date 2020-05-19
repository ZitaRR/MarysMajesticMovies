*** Settings ***
Documentation  This is some basic info about the whole test suite of infotiv rental car webpage
Resource       keywords_register.robot
Library        SeleniumLibrary

Test Setup     Begin Web Test
Test Teardown  End Web Test

*** Test Cases ***

User can check whether "Register" button exists in the web page or not to create an account
    [Documentation]  This is to check "Register" button exists in the web page
    [Tags]           Test1_RegisterButton
    Check whether "Register" button exists in the web page or not to create an account


User can check that whether user can access the web page without having an account
    [Documentation]  This is to check the access permissions for the users who have no account
    [Tags]           Test2_AccessNoAccount
    Verify the user without having an account can be able to access the web page


User can check that whether he can be able to register an account or not
    [Documentation]  This is to check the user can create an account or not
    [Tags]           Test3_CreateAccount
    Verify the user should able to Register an account


User can check that entering blank spaces on mandatory fields lead to validation error
    [Documentation]  This is to check the entering blank spaces on mandatory fields lead to validation error
    [Tags]           Test4_MandatoryBlankSpacesError
    Verify that entering blank spaces on mandatory fields lead to validation error


User can check that Enter key works as a substitute for the Submit button
    [Documentation]  This is to check the Enter key works as a substitute for the Submit button
    [Tags]           Test5_EnterKeySubmit
    Verify that Enter key works as a substitute for the Submit button


User can check that all the required/mandatory fields are marked with " * " against the field
    [Documentation]  This is to check all the required/mandatory fields are marked with " * " against the field
    [Tags]           Test6_Mandatory*
    Verify that all the required/mandatory fields are marked with " * "


User can check that the password and confirm password are same
    [Documentation]  This is to check the password and confirm password are same
    [Tags]           Test7_pwd&cpwdRSame
    Verify the password and confirm password are same


User can check that the tab functionality is working properly
    [Documentation]  This is to check the tab functionality is working properly
    [Tags]           Test8_tab
    Verify that tab functionality is working properly


User can check that the City field with invalid inputs
    [Documentation]  This is to check the City field with invalid inputs
    [Tags]           Test9_cityInvalid
    Verify the City field with invalid inputs


User can check that the Telephone number field with invalid inputs
    [Documentation]  This is to check the Telephone number field with invalid inputs
    [Tags]           Test10_PhnumInvalid
    Verify the Telephone number field with invalid inputs


User can check that the Firstname field with invalid inputs
    [Documentation]  This is to check the Firstname field with invalid inputs
    [Tags]           Test11_fnameInvalid
    Verify the Firstname field with invalid inputs


User can check that the Lasttname field with invalid inputs
    [Documentation]  This is to check the Lastname field with invalid inputs
    [Tags]           Test11_lnameInvalid
    Verify the Lastname field with invalid inputs

