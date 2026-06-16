// librarian_player_dialogue.ink

-> start

== start ==
Librarian: Welcome to the School Library. How can I assist you today?
* [Can you tell me about the library policies?] -> library_policies
* [What are the library hours?] -> library_hours
* [Just browsing, thank you.] -> end_conversation

=== library_policies ===
Librarian: Our library policies are designed to ensure that all students have fair access to resources. You can borrow up to 5 books at a time for a period of 2 weeks.
* [What happens if I return a book late?] -> late_return_policy
* [Can I reserve books?] -> reserve_books
* [Thank you for the information.] -> end_conversation

=== late_return_policy ===
Librarian: If you return a book late, there is a fine of $0.25 per day. However, if you have a genuine reason, we can discuss a waiver.
* [Thank you for letting me know.] -> end_conversation

=== reserve_books ===
Librarian: Yes, you can reserve books that are currently checked out. You will be notified via email when the book is available for pick-up.
* [That's very convenient, thank you!] -> end_conversation

=== library_hours ===
Librarian: The library is open from 8 AM to 8 PM on weekdays and from 10 AM to 4 PM on Saturdays. We are closed on Sundays.
* [Thank you for the information.] -> end_conversation

=== end_conversation ===
Librarian: If you need any further assistance, please don't hesitate to ask.
* [Goodbye.] -> END