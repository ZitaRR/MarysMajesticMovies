*** Settings ***
Library     SeleniumLibrary
Library     Collections

*** Variables ***
${BROWSER} =  chrome
${URL} =      https://localhost:44304/


*** Keywords ***
Begin Web Test
    Open Browser                about:blank   ${BROWSER}
    Maximize Browser Window
    Go To                       ${URL}


Verify that the user is able to navigate or access the different controls by pressing the ‘Tab’ key on the keyboard
    Click Link          xpath://*[@id="mainpagebody"]/footer/div[3]/p/a[1]
    Press Keys          id:Input_Email                                              TAB
    Press Keys          id:Input_Password                                           TAB
    Press Keys          xpath://*[@id="mainpagebody"]/div/main/div[2]/form/input[3]                   TAB


Verify that the validation message gets displayed in case the user leaves the username(/email) or password field as blank
    Click Link              xpath://*[@id="mainpagebody"]/footer/div[3]/p/a[1]
    Input Text              id:Input_Email                  ${EMPTY}
    Input Text              id:Input_Password               Abc123#
    #Wait Until Element Is Visible   xpath://*[@id="mainpagebody"]/div/main/div[2]/form/input[3]  3
    #Scroll Element Into View    xpath://*[@id="mainpagebody"]/div/main/div[2]/form/input[3]
    execute javascript  window.scrollTo(0,document.body.scrollHeight)
    Click Element            xpath://*[@id="mainpagebody"]/div/main/div[2]/form/input[3]
    Page Should Contain     The Email field is required.
    Input Text              id:Input_Email                  rajani.lekkala@gmail.com
    Input Text              id:Input_Password               ${EMPTY}
    #Scroll Element Into View    xpath://*[@id="mainpagebody"]/div/main/div[2]/form/input[3]
    execute javascript  window.scrollTo(0,document.body.scrollHeight)
    Click Element            xpath://*[@id="mainpagebody"]/div/main/div[2]/form/input[3]
    Page Should Contain     The Password field is required.

Verify that once logged in, clicking the back button doesn’t logout the user.
    Click Link          xpath://*[@id="mainpagebody"]/footer/div[3]/p/a[1]
    Input Text          id:Input_Email                  rajani.lekkala@gmail.com
    ${username}         Get Text                        id:Input_Email
    Input Text          id:Input_Password               Rajani123!
    #Press Keys          id:Input_Password               ENTER
    #Scroll Element Into View    xpath://*[@id="mainpagebody"]/div/main/div[2]/form/input[3]
    #Wait until Element Is Visible   xpath://*[@id="mainpagebody"]/div/main/div[2]/form/input[3]   5
    execute javascript  window.scrollTo(0,document.body.scrollHeight)
    Click Element       xpath://*[@id="mainpagebody"]/div/main/div[2]/form/input[3]
    sleep               3s
    Go Back
    sleep               3s
    Go To               ${URL}
    sleep               3s
    ${login_text}       Get Text    xpath://*[@id="mainpagebody"]/footer/h3
    should be equal     ${login_text}   You're logged in as Rajani!


Verify that there is a limit on the total number of unsuccessful login attempts.
    #So that a user cannot use a brute-force mechanism to try all possible combinations of username-password.
    Click Link              xpath://*[@id="mainpagebody"]/footer/div[3]/p/a[1]
    Input Text              id:Input_Email                  chinna.lekkala@gmail.com
    Input Text              id:Input_Password               Abc123#
    execute javascript  window.scrollTo(0,document.body.scrollHeight)
    Click Element            xpath://*[@id="mainpagebody"]/div/main/div[2]/form/input[3]
    Page Should Contain     Email or password is incorrect.
    Input Text              id:Input_Email                  chinna.lekkala@gmail.com
    Input Text              id:Input_Password               aBc123#
    execute javascript  window.scrollTo(0,document.body.scrollHeight)
    Click Element            xpath://*[@id="mainpagebody"]/div/main/div[2]/form/input[3]
    Page Should Contain     Email or password is incorrect.
    Input Text              id:Input_Email                  chinna.lekkala@gmail.com
    Input Text              id:Input_Password               qwe2!7
    execute javascript  window.scrollTo(0,document.body.scrollHeight)
    Click Element           xpath://*[@id="mainpagebody"]/div/main/div[2]/form/input[3]
    Page Should Contain     Account is locked.
    #The user cannot attempt to login more than 3 times with invalid credentials


Verify that in case of incorrect credentials, a message like “Invalid login attempt” should get displayed instead of an exact message pointing to the incorrect field.
    Click Link          xpath://*[@id="mainpagebody"]/footer/div[3]/p/a[1]
    Input Text          id:Input_Email                  harish.dinne@gmail.com
    Input Text          id:Input_Password               Harish123!
    execute javascript  window.scrollTo(0,document.body.scrollHeight)
    Click Element        xpath://*[@id="mainpagebody"]/div/main/div[2]/form/input[3]
    Page Should Contain         Email or password is incorrect.

#Verify the ‘Forgot Password’ functionality exists in the login page
    #Click Link                  xpath://*[@id="mainpagebody"]/footer/div[3]/p/a[1]
    #Page Should Contain         Forgot your password?


End Web Test
    Close Browser