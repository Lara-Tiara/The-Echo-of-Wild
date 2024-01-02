INCLUDE globals.ink
Tadhg: Magic lies not just in the casting of spells, 
Tadhg: but in the wisdom of the ages, 
Tadhg: whispered through the leaves of time.
->MageEncounter
=== MageEncounter ===
* [Approach Tadhg] Cedric: Hello there, are you the Guardian I've heard about?
    Tadhg: Yes, I am he, the guardian of arcane secrets in these woods.
    -> MageDialogue

== MageDialogue ==
    * [Ask for help] Cedric: I'm looking for a way to unlock the Arcanum Chest. Can you help me?
        Tadhg: I can sniff the power in you... But I'm gonna test your luck now!
        **[Luck] Cedric: I feel lucky today.
        {~->Success|->Fail}.
    * [Leave] ->Leave

== RiddleChallenge ==
    ** [Leave] ->Leave
    ** [Riddle] Cedric: Trust my wisdom.
    Tadhg: "My essence lies in balance and power,
    Tadhg: "Mirroring infinity hour by hour.
    Tadhg: "In my form, infinity hides,
    Tadhg: "Turn me sideways, time divides.
    Tadhg: "I represent balance and might,
    Tadhg: "Name the number that shapes me right."
    
    Cedric: The answer is a number from zero to nine.
        ***[Eight] Cedric: It's eight!
            Tadhg: Correct! The number eight is key to many mysteries. -> CorrectAnswer
        ***[Six] Cedric: Could it be six?
            -> WrongAnswer
        ***[Three] Cedric: Perhaps three?
            -> WrongAnswer

=== Leave ===
Cedric: Thank you for your time, but I must go. -> END

=== CorrectAnswer ===
*[Leave] Cedric: Thank you very much!->END
*[Gratitude and leave] Cedric: Thank you and I hope you can find the other guardians soon, wish you the best!
    Tadhg: Thank you! And don't forget eight is the first digits.->END

=== WrongAnswer ===
Tadhg: Alas, that is not the right answer. Wisdom comes with time. -> END

=== Success ===
Tadhg: Yes, you are lucky, the number is eight.->CorrectAnswer

=== Fail ===
Tadhg: Sorry, I guess today is not your day. But you can solve the riddle yourself.->RiddleChallenge     
