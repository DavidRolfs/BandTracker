��U S E   [ b a n d _ t r a c k e r ]  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ b a n d s ]         S c r i p t   D a t e :   6 / 1 7 / 2 0 1 7   1 : 5 5 : 2 4   P M   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ b a n d s ] (  
 	 [ i d ]   [ i n t ]   I D E N T I T Y ( 1 , 1 )   N O T   N U L L ,  
 	 [ n a m e ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
 	 [ p h o t o ]   [ t e x t ]   N U L L  
 )   O N   [ P R I M A R Y ]   T E X T I M A G E _ O N   [ P R I M A R Y ]  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ b a n d s _ v e n u e s ]         S c r i p t   D a t e :   6 / 1 7 / 2 0 1 7   1 : 5 5 : 2 4   P M   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ b a n d s _ v e n u e s ] (  
 	 [ i d ]   [ i n t ]   I D E N T I T Y ( 1 , 1 )   N O T   N U L L ,  
 	 [ b a n d _ i d ]   [ i n t ]   N U L L ,  
 	 [ v e n u e _ i d ]   [ i n t ]   N U L L  
 )   O N   [ P R I M A R Y ]  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ v e n u e s ]         S c r i p t   D a t e :   6 / 1 7 / 2 0 1 7   1 : 5 5 : 2 4   P M   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ v e n u e s ] (  
 	 [ i d ]   [ i n t ]   I D E N T I T Y ( 1 , 1 )   N O T   N U L L ,  
 	 [ n a m e ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
 	 [ c i t y ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
 	 [ p h o t o ]   [ t e x t ]   N U L L  
 )   O N   [ P R I M A R Y ]   T E X T I M A G E _ O N   [ P R I M A R Y ]  
 G O  
 S E T   I D E N T I T Y _ I N S E R T   [ d b o ] . [ b a n d s ]   O N    
  
 I N S E R T   [ d b o ] . [ b a n d s ]   ( [ i d ] ,   [ n a m e ] ,   [ p h o t o ] )   V A L U E S   ( 1 ,   N ' A n i m a l   C o l l e c t i v e ' ,   N ' h t t p s : / / e . s n m c . i o / l k / l / a / 8 c 5 c 2 0 9 0 0 5 8 6 e 0 4 9 3 1 2 4 2 5 3 3 e c 4 7 d d c 1 / 2 9 7 8 4 8 0 . j p g ' )  
 I N S E R T   [ d b o ] . [ b a n d s ]   ( [ i d ] ,   [ n a m e ] ,   [ p h o t o ] )   V A L U E S   ( 2 ,   N ' F u t u r e   I s l a n d s ' ,   N ' h t t p s : / / u p l o a d . w i k i m e d i a . o r g / w i k i p e d i a / c o m m o n s / 2 / 2 7 / F u t u r e _ i s l a n d s _ l i v e . j p g ' )  
 I N S E R T   [ d b o ] . [ b a n d s ]   ( [ i d ] ,   [ n a m e ] ,   [ p h o t o ] )   V A L U E S   ( 3 ,   N ' F l e e t   F o x e s ' ,   N ' h t t p s : / / i m a g e s - n a . s s l - i m a g e s - a m a z o n . c o m / i m a g e s / I / 6 1 Z a l u - S F y L . j p g ' )  
 I N S E R T   [ d b o ] . [ b a n d s ]   ( [ i d ] ,   [ n a m e ] ,   [ p h o t o ] )   V A L U E S   ( 8 ,   N ' J o y   D i v i s i o n ' ,   N ' h t t p s : / / i m g . d i s c o g s . c o m / B I t Z I p j 2 Y J 7 q 7 _ x t B h s I F N w 1 x 9 0 = / f i t - i n / 3 0 0 x 3 0 0 / f i l t e r s : s t r i p _ i c c ( ) : f o r m a t ( j p e g ) : m o d e _ r g b ( ) : q u a l i t y ( 4 0 ) / d i s c o g s - i m a g e s / A - 3 8 9 8 - 1 1 0 0 2 3 3 1 7 4 . j p g . j p g ' )  
 I N S E R T   [ d b o ] . [ b a n d s ]   ( [ i d ] ,   [ n a m e ] ,   [ p h o t o ] )   V A L U E S   ( 7 ,   N ' T h e   S m i t h s ' ,   N' http://keyassets.timeincuk.net/inspirewp/live/wp-content/uploads/sites/28/2015/02/smithsnew250215.jpg') 
 S E T   I D E N T I T Y _ I N S E R T   [ d b o ] . [ b a n d s ]   O F F  
 S E T   I D E N T I T Y _ I N S E R T   [ d b o ] . [ b a n d s _ v e n u e s ]   O N    
  
 I N S E R T   [ d b o ] . [ b a n d s _ v e n u e s ]   ( [ i d ] ,   [ b a n d _ i d ] ,   [ v e n u e _ i d ] )   V A L U E S   ( 1 ,   2 ,   1 )  
 I N S E R T   [ d b o ] . [ b a n d s _ v e n u e s ]   ( [ i d ] ,   [ b a n d _ i d ] ,   [ v e n u e _ i d ] )   V A L U E S   ( 2 ,   1 ,   6 )  
 I N S E R T   [ d b o ] . [ b a n d s _ v e n u e s ]   ( [ i d ] ,   [ b a n d _ i d ] ,   [ v e n u e _ i d ] )   V A L U E S   ( 3 ,   7 ,   1 )  
 I N S E R T   [ d b o ] . [ b a n d s _ v e n u e s ]   ( [ i d ] ,   [ b a n d _ i d ] ,   [ v e n u e _ i d ] )   V A L U E S   ( 4 ,   2 ,   5 )  
 I N S E R T   [ d b o ] . [ b a n d s _ v e n u e s ]   ( [ i d ] ,   [ b a n d _ i d ] ,   [ v e n u e _ i d ] )   V A L U E S   ( 5 ,   3 ,   1 )  
 S E T   I D E N T I T Y _ I N S E R T   [ d b o ] . [ b a n d s _ v e n u e s ]   O F F  
 S E T   I D E N T I T Y _ I N S E R T   [ d b o ] . [ v e n u e s ]   O N    
  
 I N S E R T   [ d b o ] . [ v e n u e s ]   ( [ i d ] ,   [ n a m e ] ,   [ c i t y ] ,   [ p h o t o ] )   V A L U E S   ( 1 ,   N ' C r y s t a l   B a l l r o o m ' ,   N ' P o r t l a n d ' ,   N ' h t t p : / / w w w . c r y s t a l b a l l r o o m p d x . c o m / s y s t e m / u p l o a d s / a s s e t s / S e c t i o n % 2 0 C a r o u s e l s / _ v / M G - 8 9 7 8 . j p g / h e a d e r . j p g ' )  
 I N S E R T   [ d b o ] . [ v e n u e s ]   ( [ i d ] ,   [ n a m e ] ,   [ c i t y ] ,   [ p h o t o ] )   V A L U E S   ( 5 ,   N ' W o n d e r   B a l l r o o m ' ,   N ' P o r t l a n d ' ,   N ' h t t p : / / t h e t r a v e l j o i n t . c o m / w p - c o n t e n t / u p l o a d s / 2 0 1 6 / 0 2 / w o n d e r b a l l r o o m . j p g ' )  
 I N S E R T   [ d b o ] . [ v e n u e s ]   ( [ i d ] ,   [ n a m e ] ,   [ c i t y ] ,   [ p h o t o ] )   V A L U E S   ( 6 ,   N ' P a b s t   T h e a t e r ' ,   N ' M i l w a u k e e ' ,   N ' h t t p : / / w w w . m i l w a u k e e 3 6 5 . c o m / w p - c o n t e n t / u p l o a d s / s i t e s / w w w . m i l w a u k e e 3 6 5 . c o m / i m a g e s / v e n u e / 2 7 6 7 / p a b s t - t h e a t e r - i n t . j p g ' )  
 S E T   I D E N T I T Y _ I N S E R T   [ d b o ] . [ v e n u e s ]   O F F  
 
