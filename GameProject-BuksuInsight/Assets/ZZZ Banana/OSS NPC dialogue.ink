// ID validation.ink

-> start

== start ==
OVPCASSS Personnel: Hello. This is the OVPCASSS. How can I help you?
* [ ] -> po1

=== po1 === 
You: Greetings, ma’am. I was told that I could get my I.D. validated here. But before anything, I was wondering, what is the meaning of OVPCASSS?
* [ ] -> rp1

=== rp1 ===
OVPCASSS Personnel: OVPCASSS stands for Office of the Vice President for culture, arts, sports, and student services. -> cnt7

=== cnt7 ===
* [ ] -> po5

=== po5 ===
It oversees the various aspects of student affairs in this University. It also aims to promote the cultural, artistic, and athletic growth of the students.
* [ ] -> po2

=== po2 ===
You: Aaaah… So, this is the place to run to when students need support services. Okay. Guess I’ll be asking my very first support from here which is to help me get my ID validated.

* [ ] -> rp2

=== rp2 ===
OVPCASSS Personnel: Yes, we’re glad to help. -> cnt3

=== cnt3 ===
* [ ] -> po3

=== po3 ===
OVPCASSS Personnel: If you have your University ID and Certificate of Registration with you, we can start processing it already. -> cnt4

=== cnt4 ===
* [ ] -> po4

=== po4 ===
You: I have it with me. Here you go, ma’am.


* [ ] -> END