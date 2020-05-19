*** Settings ***
Documentation  This is some basic info about the whole test suite of infotiv rental car webpage
Resource     keywords_login.robot
Library        SeleniumLibrary


Test Setup     Begin Web Test
Test Teardown  End Web Test


*** Test Cases ***
User can check whether he can navigate the controls by pressing TAB key
    [Documentation]  This is to check naviagtion through TAB key
    [Tags]           Test_NavigationTABkey
    Verify that the user is able to navigate or access the different controls by pressing the ‘Tab’ key on the keyboard


User can check validation message gets displayed in case the user leaves the username(/email) or password field as blank
    [Documentation]  This is to check validation message gets displayed
    [Tags]           Test_Validation
    Verify that the validation message gets displayed in case the user leaves the username(/email) or password field as blank


User can check that once logged in, clicking the back button doesn’t logout the user.
    [Documentation]  This is to check ‘Forgot Password’ functionality exists in the login page
    [Tags]           Test_Backbutton
    Verify that once logged in, clicking the back button doesn’t logout the user.


User can check that there is a limit on the total number of unsuccessful login attempts
    [Documentation]  This is to check limit for unsuccessful attempts
    [Tags]           Test_LimitAttempts
    Verify that there is a limit on the total number of unsuccessful login attempts.


User can check that in case of incorrect credentials, a message like “Invalid login attempt” should get displayed
    [Documentation]  This is to check Invalid login attempt is displayed for incorrect credentials
    [Tags]           Test_InValidLogin
    Verify that in case of incorrect credentials, a message like “Invalid login attempt” should get displayed instead of an exact message pointing to the incorrect field.



#User can check that the ‘Forgot Password’ functionality exists in the login page(not yet implemented for sprint2)
    #[Documentation]  This is to check ‘Forgot Password’ functionality exists in the login page
    #[Tags]           Test_ForgotPwd
    #Verify the ‘Forgot Password’ functionality exists in the login page


