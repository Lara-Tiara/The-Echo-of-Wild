 EXTERNAL playSound(soundName)
 EXTERNAL loadScene(sceneName)

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
                **** [Use Magic] //触发魔法音效
                ~ playSound("Magic") 
                -> Magic_Helping
                
                
                **** [Use Brutal Force] //触发大力出奇迹音效
                ~ playSound("Force")
                -> Mannual_Helping
                
        
        
    === Refuse_Ending ===
    You refused to save the lion.
    ~ loadScene("Ending1")
    -> END
    
    === Magic_Helping ==
    You decide to use the forbidden magic to save the lion. 
    * [Leave]
    ~ loadScene("CutscenePrison")
    -> END
    
    === Mannual_Helping ===
    You opend the trap with your hands.
    * [Leave]
    ~ loadScene("CutscenePrison")
    -> END