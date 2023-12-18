INCLUDE GlobalVariables.ink

Please! I need help!
* [Ignore] Sorry, I'm a little busy right now. -> END
* [Asking] What happened to you.
    -> Divert1
    
    == Divert1 ==
    Someone put a trap here, and I accidentally dropped in it.
    * [Who did this to you] Do you have any idea who put this trap here?
        I have no idea, maybe the guard at the end of the forest would know.
        ** [Go Back] -> Divert1
    * [What do you want] What do you want?
        Could you help me get rid of this trap please?
        ** [No] I don't think this is a good idea to let a such dangerous lion out... -> Refuse_Ending
        ** [Yes] Sure, I would love to help a lion, you are not going to bite me right?
            Of course not, I would never hurt someone who saved me. But of course, I would not let go those who hurt me.
            *** [How can I help you] Let me see... This is a tight trap.
                If you can use your magic to unlock me...
                **** [Use Magic] -> Magic_Helping
                //触发魔法动画和音效
                **** [Use Brutal Force] -> Mannual_Helping
                //触发大力出奇迹动画和音效
        
        
    === Refuse_Ending ===
    ~ refuse_Lion = true
    You refused to save the lion.
    -> END
    
    === Magic_Helping ==
    ~ save_Lion_magic = true
    You decide to use the forbidden magic to save the lion.
    -> END
    
    === Mannual_Helping ===
    ~ save_Lion_mannual = true
    You opend the trap with your hands.
    -> END