INCLUDE globals.ink
The Mage: Magic lies not just in the casting of spells, 
The Mage: but in the wisdom of the ages, 
The Mage: whispered through the leaves of time.
->MageEncounter
=== MageEncounter ===
* [Approach The Mage] Cedric: Hello there, are you the Guardian I've heard about?
    The Mage: Yes, I am he, the guardian of arcane secrets in these woods.
    -> MageDialogue

== MageDialogue ==
    * [Ask for help] Cedric: I'm looking for a way to unlock the Arcanum Chest. Can you help me?
        The Mage: I can sniff the power in you... But I'm gonna test your luck now!
        **[Luck] Cedric: I feel lucky today.
        {~->Success|->Fail}.
    * [Leave] ->Leave

== RiddleChallenge ==
    ** [Leave] ->Leave
    ** [Riddle] Cedric: Trust my wisdom.
    The Mage: "My essence lies in balance and power,
    The Mage: "Mirroring infinity hour by hour.
    The Mage: "In my form, infinity hides,
    The Mage: "Turn me sideways, time divides.
    The Mage: "I represent balance and might,
    The Mage: "Name the number that shapes me right."
    
    Cedric: The answer is a number from zero to nine.
        ***[Eight] Cedric: It's eight!
            The Mage: Correct! The number eight is key to many mysteries. -> CorrectAnswer
        ***[Six] Cedric: Could it be six?
            -> WrongAnswer
        ***[Three] Cedric: Perhaps three?
            -> WrongAnswer
=== Leave ===
Cedric: Thank you for your time, but I must go. -> END

=== CorrectAnswer ===
*[Leave] Cedric: Thank you very much!->END
*[Gratitude and leave] Cedric: Thank you and I hope you can find the other guardians soon, wish you the best!
    The Mage: Thank you! And don't forget eight is the first digits.->END

=== WrongAnswer ===
The Mage: Alas, that is not the right answer. Wisdom comes with time. -> END

=== Success ===
The Mage: Yes, you are lucky, the number is eight.->CorrectAnswer

=== Fail ===
The Mage: Sorry, I guess today is not your day. But you can solve the riddle yourself.->RiddleChallenge     