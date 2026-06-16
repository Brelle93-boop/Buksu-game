// guard_welcoming_new_student.ink

-> start

== start ==
Guard: Good morning! Welcome to the University. Are you a new student here?
* [ ] -> first_day1

=== first_day1 ===
You: Yes, I am. This is my first day. 
* [ ] -> first_day

=== first_day ===
Guard: Great! Welcome to our community. Do you have your student ID with you?
* [ ] -> a
=== a ===
You: No, I haven't received it yet.
* [ ] -> no_id

=== no_id ===
Guard: That's okay. You can get your student ID from the University Press office. It's the second building on your right as you enter. If you need any help, just ask any of the staff. Have a great first day!
* [ ] -> b
=== b ===
Thank you, I'll head there now. 
* [ ] -> end_conversation

=== just_visiting ===
Guard: I see. Well, enjoy your visit. If you need any assistance, don't hesitate to ask. Have a good day!
* [Thank you!] -> end_conversation

=== end_conversation ===
Guard: Take care and welcome once again. Have a good day!
* [ ] -> END
