Feature: MobyMax Registration
Feature details
	
@RegistrationTest_EndToEnd
Scenario Outline: End to End registration
	Description: test registration

	Given I have navigated to URL <URL> in browser <browser>
	When I have entered firstname <firstname> into <firstname field> and lastname <lastname> into <lastname field>
	And I have entered educator <educator> into <educator checkbox> of attribute "data-checked" 
	And I have entered zipcode <zipcode> into <zipcode field> and school <schoolId> into <school field>
	And I have entered email address <email address> into <email field> and password <password> into <password field>
	And I press the Register button identified by <register xpath>
	Then the result welcome page identified by dismissing the modal <welcome modal> contains title <welcome xpath> matching <firstname> <lastname> and URL is <WelcomeURL>
	
Examples: 
| URL                     | browser | firstname | firstname field                               | lastname | lastname field                                | educator | educator checkbox                                  | zipcode | zipcode field                                 | schoolId | school field                                     | email address    | email field                                    | password | password field                                     | register xpath             | welcome modal                      | welcome xpath      | WelcomeURL                           |
| http://www.mobymax.com/ | IE      | John      | //*[@id="register-element-form"]/div[1]/input | Doe1     | //*[@id="register-element-form"]/div[2]/input | teacher  | //*[@id="register-element-form"]/div[3]/div[1]/img | 15122   | //*[@id="register-element-form"]/div[8]/input | 13560    | //*[@id="register-element-form"]/div[9]/input[1] | jdoe586@gmail.com | //*[@id="register-element-form"]/div[13]/input | abc123   | //*[@id="register-element-form"]/div[14]/div/input | //*[@id="register-button"] | //*[@id="video-dialog"]/div/div[2] | //*[@id="welcome"] | http://www.mobymax.com/MM/MT/Welcome |
| http://www.mobymax.com/ | Chrome  | John      | //*[@id="register-element-form"]/div[1]/input | Doe 2    | //*[@id="register-element-form"]/div[2]/input | teacher  | //*[@id="register-element-form"]/div[3]/div[1]/img | 15122   | //*[@id="register-element-form"]/div[8]/input | 13560    | //*[@id="register-element-form"]/div[9]/input[1] | jdoe70@gmail.com  | //*[@id="register-element-form"]/div[13]/input | jd12342  | //*[@id="register-element-form"]/div[14]/div/input | //*[@id="register-button"] | //*[@id="video-dialog"]/div/div[1] | //*[@id="welcome"] | http://www.mobymax.com/MM/MT/Welcome |
#| http://www.mobymax.com/ | Safari  | John      | //*[@id="register-element-form"]/div[1]/input | Doe 3    | //*[@id="register-element-form"]/div[2]/input | teacher  | //*[@id="register-element-form"]/div[3]/div[1]/img | 15122   | //*[@id="register-element-form"]/div[8]/input | 13560    | //*[@id="register-element-form"]/div[9]/input[1] | jdoe67@gmail.com  | //*[@id="register-element-form"]/div[13]/input | jd12343  | //*[@id="register-element-form"]/div[14]/div/input | //*[@id="register-button"] | //*[@id="video-dialog"]/div/div[1] | //*[@id="welcome"] | http://www.mobymax.com/MM/MT/Welcome |
#| http://www.mobymax.com/ | Firefox | John      | //*[@id="register-element-form"]/div[1]/input | Doe 4    | //*[@id="register-element-form"]/div[2]/input | teacher  | //*[@id="register-element-form"]/div[3]/div[1]/img | 15122   | //*[@id="register-element-form"]/div[8]/input | 13560    | //*[@id="register-element-form"]/div[9]/input[1] | jdoe68@gmail.com  | //*[@id="register-element-form"]/div[13]/input | jd12344  | //*[@id="register-element-form"]/div[14]/div/input | //*[@id="register-button"] | //*[@id="video-dialog"]/div/div[1] | //*[@id="welcome"] | http://www.mobymax.com/MM/MT/Welcome |

@mytag
Scenario Outline: Test If School dropdown list populates with appropriate schools upon entering correct zip code
	Given I have navigated to the URL <URL> in browser <browser>
	When I enter the zip code <zipcode> into <zipcode field> and click the school dropdown <school field> containing <List of Schools per zip>
	Then School dropdown list should include the list of schools <List of Schools per zip>

Examples: 
	| URL                     | browsers | zipcode | zipcode field                                 | school field                                     | List of Schools per zip                                                                                                                                                                                                                                               |
	| http://www.mobymax.com/ | IE       | 15122   | //*[@id="register-element-form"]/div[8]/input | //*[@id="register-element-form"]/div[9]/input[1] | Calvary Baptist Preschool & Kind, Clara Barton El Sch, Early Childhood Education Center,Homeville El Sch,New Emerson El Sch,New England El Sch,St Agnes School,Walnut Grove Christian School,West Mifflin Area Hs,Wilson Christian Academy,School not listed?         |
	| http://www.mobymax.com/ | Chrome   | 15122   | //*[@id="register-element-form"]/div[8]/input | //*[@id="register-element-form"]/div[9]/input[1] | Calvary Baptist Preschool & Kind, Clara Barton El Sch, Early Childhood Education Center, Homeville El Sch, New Emerson El Sch, New England El Sch, St Agnes School, Walnut Grove Christian School, West Mifflin Area Hs, Wilson Christian Academy, School not listed? |
	#| http://www.mobymax.com/ | Safari   | 15122   | //*[@id="register-element-form"]/div[8]/input | //*[@id="register-element-form"]/div[9]/input[1] | Calvary Baptist Preschool & Kind, Clara Barton El Sch, Early Childhood Education Center, Homeville El Sch, New Emerson El Sch, New England El Sch, St Agnes School, Walnut Grove Christian School, West Mifflin Area Hs, Wilson Christian Academy, School not listed? |
	#| http://www.mobymax.com/ | Firefox  | 15122   | //*[@id="register-element-form"]/div[8]/input | //*[@id="register-element-form"]/div[9]/input[1] | Calvary Baptist Preschool & Kind, Clara Barton El Sch, Early Childhood Education Center, Homeville El Sch, New Emerson El Sch, New England El Sch, St Agnes School, Walnut Grove Christian School, West Mifflin Area Hs, Wilson Christian Academy, School not listed? |