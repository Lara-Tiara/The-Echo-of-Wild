INCLUDE globals.ink

Niamh: Oh, another lost person... 

* [Who are you?] Cedric: Hi, I'm Cedric, a shepherd. What about you?
    Niamh: I have lived here for a thousand years
    Niamh: You may have heard from the tales that there are guardians of the Kingdom of Eldoria... 
    -> Divert1
* [Ignore] Cedric: Sorry, I'm a little busy right now. -> END
* {check_chest}[Ask about the mystical chest] Cedric: I found a magical chest in this woods. Do you know how to open it?
    Niamh: Ah, the Arcanum Chest! 
    Niamh: It's locked by Bunny the Witch, she kept her secret in there. 
    Niamh: You need three digits to open it. 
    Niamh: I only know one of them. 
    Niamh: You want the number? Count on your luck or wisdom?->Divert3
    
     == Divert1 ==
        ** [What happened?] Cedric: You mean you were one of them? What happened to the guardians?
           Niamh: It's Bunny the Witch, she now rules the Kingdom of Eldoria.
           Niamh: She has even captured Oisin, our leader, the great lion who guided us.
           -> Divert1
        ** [Guardians?] Cedric: What exactly are these guardians supposed to guard?
            Niamh: We were the keepers of balance, ensuring harmony between all magical and mortal realms.
            Niamh: But our power waned as Bunny's grew.
            -> Divert1
        ** [Can you still guard?] Cedric: Is there no power left among you to oppose her?
            Niamh: Our magic is bound to the land.
            Niamh: It weakens as the land suffers. 
            Niamh: But hope remains while the heart of Eldoria still beats, and Oisin's spirit inspires us still.
            -> Divert2
            
            == Divert2 ==
            *** [Oppose Bunny?] Cedric: How can Bunny be opposed if she controls the kingdom?
                Niamh: The old magic runs deep, and secrets lost await the worthy.
                Niamh: One such secret is the Echo of Eldoria
                Niamh: A power that could restore balance.-> Divert2
            *** [Echo of Eldoria?] Cedric: What is this Echo of Eldoria?
                Niamh: It's an ancient force, tied to the first guardians. 
                Niamh: It can only be summoned by one who proves their worth and knows the kingdom's heart. 
                Niamh: Perhaps it could even break the chains that bind Oisin.-> Divert2
            ***[Leave] Cedric: Thank you for the information. I need to go.-> DONE
                

    == Divert3 ==
    **[Luck] Cedric: I feel lucky today.
    {~->Success|->Fail}.
    
    **[Wisdom]
    Niamh: The number is kept by an ancient riddle, known only to few. 

    Niamh: "From the heaven to the deep sea floor,
    Niamh: "My reach spans across folklore.
    Niamh: "In colors cast across the sky,
    Niamh: "In notes where music's secrets lie.
    Niamh: "From the spectrum's end to the chord's delight,
    Niamh: "Tell me the number that fits just right."
    
    Niamh: The answer is a number from zero to nine.
        ***[Seven]Cedric: It's seven!
        Niamh: Yes, you are right! Go solve the other numbers and find out the secret.
        ~ solve_Niamh = true
        ->Right_Answer
        ***[Eight]Cedric: It must be eight.
        ->Wrong_Answer
        ***[Three]Cedric: Is it three?
        ->Wrong_Answer
        
=== Right_Answer ===
*[Leave] Cedric: Thank you very much!->END
*[Gratitude and leave] Cedric: Thank you and I hope you can find the other guardians soon, wish you the best!
    ~ greet_Niamh = true
    Niamh: Thank you! And don't forget seven is the third digits.->END

=== Wrong_Answer ===
Niamh: No, I don't think that is the right number.->END
        
=== Success ===
Niamh: Yes, you are lucky, the number is seven.->Right_Answer

=== Fail ===
Niamh: Sorry, I guess today is not your day.->Divert3     
 