INCLUDE globals.ink

The Fairy: Oh, another lost person... Have you chacked the chest?

*[Yes] Cedric: Yes. 
~ check_chest = true
->Divert4
*[No] Cedric: No.
->Divert4

     == Divert1 ==
        ** [What happened?] Cedric: You mean you were one of them? What happened to the guardians?
           The Fairy: It's Bunny the Witch, she now rules the Kingdom of Eldoria. 
           -> Divert1
        ** [Guardians?] Cedric: What exactly are these guardians supposed to guard?
            The Fairy: We were the keepers of balance, ensuring harmony between all magical and mortal realms.
            The Fairy: But our power waned as Bunny's grew.
            -> Divert1
        ** [Can you still guard?] Cedric: Is there no power left among you to oppose her?
            The Fairy: Our magic is bound to the land.
            The Fairy: It weakens as the land suffers. 
            The Fairy: But hope remains while the heart of Eldoria still beats.
            -> Divert2
            
            == Divert2 ==
            *** [Oppose Bunny?] Cedric: How can Bunny be opposed if she controls the kingdom?
                The Fairy: The old magic runs deep, and secrets lost await the worthy.
                The Fairy: One such secret is the Echo of Eldoria
                The Fairy: A power that could restore balance.-> Divert2
            *** [Echo of Eldoria?] Cedric: What is this Echo of Eldoria?
                The Fairy: It's an ancient force, tied to the first guardians. 
                The Fairy: It can only be summoned by one who proves their worth and knows the kingdom's heart. -> Divert2
            ***[Leave] Cedric: Thank you for the information. I need to go.-> DONE
                
== Divert4 ==
* [Who are you?] Cedric: Hi, I'm Cedric, a shepherd. What about you?
    The Fairy: I have lived here for thousand years
    The Fairy: You may heard from the tales that there are guardians of the Kingdom of Eldoria... 
    -> Divert1
* [Ignore] Cedric: Sorry, I'm a little busy right now. -> END
* {check_chest}[Ask about the mystical chest] Cedric: I found a magical chest in this woods. Do you know how to open it?
    The Fairy: Ah, the Arcanum Chest! 
    The Fairy: It's locked by Bunny the Witch, she kept her secret in there. 
    The Fairy: You need three digits to open it. 
    The Fairy: I only know one of them. 
    The Fairy: You want the number? Count on your luck or wisdom?->Divert3
    
    == Divert3 ==
    **[Luck] Cedric: I feel lucky today.
    {~->Success|->Fail}.
    
    **[Wisdom]
    The Fairy: The number is kept by an ancient riddle, known only to few. 

    The Fairy: "From the heaven to the deep sea floor,
    The Fairy: "My reach spans across folklore.
    The Fairy: "In colors cast across the sky,
    The Fairy: "In notes where music's secrets lie.
    The Fairy: "From the spectrum's end to the chord's delight,
    The Fairy: "Tell me the number that fits just right."
    
    The Fairy: The answer is a number from zero to nine.
        ***[Seven]Cedric: It's seven!
        The Fairy: Yes, you are right! Go solve the other numbers and find out the secret.
        ->Right_Answer
        ***[Eight]Cedric: It must be eight.
        ->Wrong_Answer
        ***[Three]Cedric: Is it three?
        ->Wrong_Answer
        
=== Right_Answer ===
*[Leave] Cedric: Thank you very much!->END
*[Greet and leave] Cedric: Thank you and I hope you can find the other guardians soon, wish you the best!
    The Fairy: Thank you! And don't forget seven is the third digits.->END

=== Wrong_Answer ===
The Fairy: No, I don't think that is the right number.->END
        
=== Success ===
The Fairy: Yes, you are lucky, the number is seven.->Right_Answer

=== Fail ===
The Fairy: No, I guess today is not your day.->Divert3     