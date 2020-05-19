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


#Verify Title Of Home Page
    #${link_text} =       Get Text        xpath:/html/body/header/nav/div/a
    #Should Be Equal      ${link_text}    MarysMajesticMovies


Check whether "Register" button exists in the web page or not to create an account
    #Page Should Contain Element          xpath:/html/body/header/nav/div/div/ul[1]/li[1]/a
    ${link_text}        Get Text        xpath://*[@id="mainpagebody"]/footer/div[3]/p/a[2]
    Should Be Equal     ${link_text}    create an account


Verify the user without having an account can be able to access the web page
    Click Link          xpath://*[@id="mainpagebody"]/header/div/a[1]
    Click Link          xpath://*[@id="mainpagebody"]/header/div/a[2]
    Click Link          xpath://*[@id="mainpagebody"]/header/div/a[3]


Verify the user should able to Register an account
    Click Link          xpath://*[@id="mainpagebody"]/footer/div[3]/p/a[2]
    Input Text          id:Input_FirstName              Ammulu
    Input Text          id:Input_LastName               Kavya
    Input Text          id:Input_Address                Sweden
    Input Text          id:Input_ZipCode                61235
    Input Text          id:Input_City                   Göteborg
    Input Text          id:Input_PhoneNumber            1234567891
    Input Text          id:Input_Email                  ammulu.kavya@gmail.com
    ${email_text}       Get Value                       id:Input_Email
    Input Text          id:Input_Password               Ammulu123!
    Input Text          id:Input_ConfirmPassword        Ammulu123!
    Click Button        xpath://*[@id="mainpagebody"]/div/main/div[2]/form/input[10]
    ${login_text}       Get Text     xpath://*[@id="mainpagebody"]/footer/h3
    Should Be Equal     ${login_text}       You're logged in as Ammulu!


Verify that entering blank spaces on mandatory fields lead to validation error
    Click Link              xpath://*[@id="mainpagebody"]/footer/div[3]/p/a[2]
    Input Text              id:Input_FirstName                                                      ${SPACE}
    Press Keys              id:Input_FirstName                                                      TAB
    ${fname_error_text}     Get Text                                                                id:Input_FirstName-error
    Should Be Equal         Use letters only please                                                 ${fname_error_text}
    Input Text              id:Input_LastName                                                       ${SPACE}
    Press Keys              id:Input_LastName                                                       TAB
    ${lname_error_text}     Get Text                                                                id:Input_LastName-error
    Should Be Equal         Use letters only please                                                 ${lname_error_text}
    #Input Text              id:Input_Address                                                        ${SPACE}
    #Press Keys              id:Input_Address                                                        TAB
    #${address_error_text}   Get Text                                                                id:Input_Address-error
    #Should Be Equal         Only numbers, letters, space and ,./- are allowed                       ${address_error_text}
    Input Text              id:Input_City                                                           ${SPACE}
    Press Keys              id:Input_City                                                           TAB
    ${city_error_text}      Get Text                                                                id:Input_City-error
    Should Be Equal         Use letters only please                                                 ${city_error_text}
    Input Text              id:Input_ZipCode                                                        ${SPACE}
    Press Keys              id:Input_ZipCode                                                        TAB
    ${zipcode_error_text}   Get Text                                                                id:Input_ZipCode-error
    Should Be Equal         The zipcode must be 5 numbers long                                      ${zipcode_error_text}
    Input Text              id:Input_PhoneNumber                                                    ${SPACE}
    Press Keys              id:Input_PhoneNumber                                                    TAB
    ${phno_error_text}      Get Text                                                                id:Input_PhoneNumber-error
    Should Be Equal         The Telephone must only contain numbers and be 9-13 digits long         ${phno_error_text}
    Input Text              id:Input_Email                                                          ${SPACE}
    Press Keys              id:Input_Email                                                          TAB
    ${email_error_text}     Get Text                                                                id:Input_Email-error
    Should Be Equal         The Email field is not a valid e-mail address.                          ${email_error_text}
    #Input Text              id:Input_Password                                                       ${SPACE}
    #Press Keys              id:Input_Password                                                       TAB
    #${pwd_error_text}       Get Text                                                                id:Input_Password-error
    #Should Be Equal         The Password field is required.                                         ${pwd_error_text}
    #Input Text              id:Input_ConfirmPassword                                                ${SPACE}
    #Press Keys              id:Input_ConfirmPassword                                                TAB
    #${cnfmpwd_error_text}   Get Text                                                                id:Input_ConfirmPassword-error
    #Should Be Equal         The Confirm Password field is required.                                 ${cnfmpwd_error_text}

Verify that Enter key works as a substitute for the Submit button
    Click Link          xpath://*[@id="mainpagebody"]/footer/div[3]/p/a[2]
    Press Keys          id:Input_ConfirmPassword    ENTER


Verify that all the required/mandatory fields are marked with " * "
    Click Link                 xpath://*[@id="mainpagebody"]/footer/div[3]/p/a[2]
    ${attr_fname}              Get Element Attribute        id:Input_FirstName      attribute=placeholder
    Should Be Equal            ${attr_fname}                First name *
    ${attr_lname}              Get Element Attribute        id:Input_LastName       attribute=placeholder
    Should Be Equal            ${attr_lname}                Last name *
    ${attr_addr}               Get Element Attribute        id:Input_Address        attribute=placeholder
    Should Be Equal            ${attr_addr}                 Address *
    ${attr_city}               Get Element Attribute        id:Input_City           attribute=placeholder
    Should Be Equal            ${attr_city}                 City *
    ${attr_zip}                Get Element Attribute        id:Input_ZipCode        attribute=placeholder
    Should Be Equal            ${attr_zip}                  Zip code *
    ${attr_phno}               Get Element Attribute        id:Input_PhoneNumber    attribute=placeholder
    Should Be Equal            ${attr_phno}                 Phone *
    ${attr_email}              Get Element Attribute        id:Input_Email    attribute=placeholder
    Should Be Equal            ${attr_email}                Email *
    ${attr_pwd}                Get Element Attribute        id:Input_Password    attribute=placeholder
    Should Be Equal            ${attr_pwd}                  Password *
    ${attr_cpwd}               Get Element Attribute        id:Input_ConfirmPassword    attribute=placeholder
    Should Be Equal            ${attr_cpwd}                 Verify password *


Verify the password and confirm password are same
    Click Link              xpath://*[@id="mainpagebody"]/footer/div[3]/p/a[2]
    Input Text              id:Input_Email                  kavya.hasini@gmail.com
    Input Text              id:Input_Password               Asd123!
    Input Text              id:Input_ConfirmPassword        Aqd123!
    Press Keys              id:Input_ConfirmPassword        TAB
    Page Should Contain     The confirmation password do not match.


Verify that tab functionality is working properly
    Click Link          xpath://*[@id="mainpagebody"]/footer/div[3]/p/a[2]
    Press Keys          id:Input_Email                  TAB
    Press Keys          id:Input_Password               TAB
    Press Keys          id:Input_ConfirmPassword        TAB
    Press Keys          id:Input_FirstName              TAB
    Press Keys          id:Input_LastName               TAB
    Press Keys          id:Input_Address                TAB
    Press Keys          id:Input_ZipCode                TAB
    Press Keys          id:Input_City                   TAB
    Press Keys          id:Input_PhoneNumber            TAB


Verify the City field with invalid inputs
    Click Link          xpath://*[@id="mainpagebody"]/footer/div[3]/p/a[2]
    ${cityErr}          Set Variable                    Use letters only please
    Input Text          id:Input_City                   12345
    Press Keys          id:Input_City                   TAB
    ${city_error}       Get Text                        id:Input_City-error
    Should Be Equal     ${city_error}                   ${cityErr}
    Input Text          id:Input_City                   !"#¤¤%&
    Press Keys          id:Input_City                   TAB
    ${city_error}       Get Text                        id:Input_City-error
    Should Be Equal     ${city_error}                   ${cityErr}
    Input Text          id:Input_City                   asd123___
    Press Keys          id:Input_City                   TAB
    ${city_error}       Get Text                        id:Input_City-error
    Should Be Equal     ${city_error}                   ${cityErr}


Verify the Telephone number field with invalid inputs
    Click Link          xpath://*[@id="mainpagebody"]/footer/div[3]/p/a[2]
    ${phErr}            Set Variable                    The Telephone must only contain numbers and be 9-13 digits long
    Input Text          id:Input_PhoneNumber            ${SPACE}
    Press Keys          id:Input_PhoneNumber            TAB
    ${phnum_error}      Get Text                        id:Input_PhoneNumber-error
    Should Be True      '${phnum_error}'=='${phErr}'
    Input Text          id:Input_PhoneNumber            0114684767734
    Press Keys          id:Input_PhoneNumber            TAB
    ${phnum_error}      Get Text                        id:Input_PhoneNumber-error
    #Should Be Equal     ${phnum_error}                  The Telephone must only contain numbers and be 9-13 digits long
    Should Be True      '${phnum_error}'=='${phErr}'
    Input Text          id:Input_PhoneNumber            sdfsdfdgdfgf
    Press Keys          id:Input_PhoneNumber            TAB
    ${phnum_error}      Get Text                        id:Input_PhoneNumber-error
    Should Be True      '${phnum_error}'=='${phErr}'
    Input Text          id:Input_PhoneNumber            "¤"#%¤#%#¤
    Press Keys          id:Input_PhoneNumber            TAB
    ${phnum_error}      Get Text                        id:Input_PhoneNumber-error
    Should Be True      '${phnum_error}'=='${phErr}'
    Input Text          id:Input_PhoneNumber            +46-73456789
    Press Keys          id:Input_PhoneNumber            TAB
    ${phnum_error}      Get Text                        id:Input_PhoneNumber-error
    Should Be True      '${phnum_error}'=='${phErr}'


Verify the Firstname field with invalid inputs
    Click Link          xpath://*[@id="mainpagebody"]/footer/div[3]/p/a[2]
    Input Text          id:Input_FirstName            ${SPACE}
    Press Keys          id:Input_FirstName            TAB
    ${fname_error}      Get Text                      id:Input_FirstName-error
    Should Be Equal     ${fname_error}                Use letters only please
    Input Text          id:Input_FirstName            0114684767734
    Press Keys          id:Input_FirstName            TAB
    ${fname_error}      Get Text                      id:Input_FirstName-error
    Should Be Equal     ${fname_error}                Use letters only please
    Input Text          id:Input_FirstName            !"¤"#%#¤&¤%&
    Press Keys          id:Input_FirstName            TAB
    ${fname_error}      Get Text                      id:Input_FirstName-error
    Should Be Equal     ${fname_error}                Use letters only please
    Input Text          id:Input_FirstName            <html>test<html>
    Press Keys          id:Input_FirstName            TAB
    ${fname_error}      Get Text                      id:Input_FirstName-error
    Should Be Equal     ${fname_error}                Use letters only please


Verify the Lastname field with invalid inputs
    Click Link          xpath://*[@id="mainpagebody"]/footer/div[3]/p/a[2]
    Input Text          id:Input_LastName            ${SPACE}
    Press Keys          id:Input_LastName            TAB
    ${lname_error}      Get Text                      id:Input_LastName-error
    Should Be Equal     ${lname_error}                Use letters only please
    Input Text          id:Input_LastName            0114684767734
    Press Keys          id:Input_LastName            TAB
    ${lname_error}      Get Text                      id:Input_LastName-error
    Should Be Equal     ${lname_error}                Use letters only please
    Input Text          id:Input_LastName            !"¤"#%#¤&¤%&
    Press Keys          id:Input_LastName            TAB
    ${lname_error}      Get Text                      id:Input_LastName-error
    Should Be Equal     ${lname_error}                Use letters only please
    Input Text          id:Input_LastName            <html>test<html>
    Press Keys          id:Input_LastName            TAB
    ${lname_error}      Get Text                      id:Input_LastName-error
    Should Be Equal     ${lname_error}                Use letters only please


End Web Test
    Close Browser