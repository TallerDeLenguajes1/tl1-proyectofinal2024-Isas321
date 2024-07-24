namespace EspacioImagenes;

class Imagenes(){
  public static void caballero(){

      string[] asciiArt = new string[]
        {
            "",
            "",
            "                                         .:kkdc. ",                                                                                 
            "                               .;ldxkOOkxdxKMMWXd.",                                                                             
            "                            'ckXWMMMMMMMMMMMMMMMW0d; .'",                                                                            
            "                .'.     .'ckXMMMMMMMMMMMMMMMMMMMMMMO:d0,",                                                                         
            "               .dNKxolox0NMMMMMMMMMMMMMMMMMMMMMMMMMWNWK,",                                                                   
            "               .kMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMXo::cloooolc:,.",                                                                   
            "                oWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWNNNNNWWWXOdc'",                                                                   
            "                .xWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMXd;'...',:lxKNWNOc.   .",                                                                   
            "                 .c0NMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMK:           .,lONWKdlkO:",                                                 
            "                   .,cdKMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWo               .:0WMMMMX:",                                            
            "                     .lKMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMNl              .;oKWW0kXMX:",                                        
            "                   .cOWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMKl.        .'cxKWWXk:. cNM0,",                                     
            "        .... ...,cxKWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWXOkddoodk0NWWKxc.    .xWWk.",                              
            "        'kK000KNWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWNKxl;.        ;KMNc ",                            
            "         ;0WMMMMMMMMMMMMMMMMMMMMMMMMMMWNNMMMMMMMMMMMMMMMMMWNKkdoc;,;::ccloodddo;'kMMx.",                           
            "          .l0WMMMMMMMMMMMMMMMMMMMMMMMWx,dWMMMMMMMMMMMMMMMMWXOl.   .xWMMMMMMMMMMXclNM0'",                          
            "            .,lk0XNWWWNNX00NMMMMMMMMWx. ;XMMMMMMMMMMMMMMMMMMMNl    'OWMMMMMMMMMM0xXMX;",                          
            "                ..'',,'.. ,0MMMMMMMXo.  .OMMMMMMMMMMMMMMMMMMMWo     .ckXWMMMMMMMMWWMWkc.",                         
            "                          ;XMMMMWKd,     lWMMMMMMMMMMMMMMMMMMO'    .'. .,:loxk0KXXNWMMNl",                        
            "                          l00Oxo:.       .kMMMMMMMMMMMMMMMMMX:     'ko  .,'   ....'lXMX:",                       
            "                           ..            .kWMMMMMMMMMMMMMMMM0'    .d0;  ,0O.  ,xl. cNMO.",                       
            "                                        :0WWNWMMMMMMMMMMMMMMNo.  .oKl  'kKc   lKl .kMWo ",                      
            "                                     .,xNWKlcKMMMMMMWWMMMMMMMW0l'.;;. ;0No.  cKx..oNM0'",                      
            "                             .;codkkO0NMMNko0WMMMMWO:;lONWMMMMMMNOl' .:xc. .dXk. cXMX: ",                      
            "                         .,oOXWMMMMMMMMMMMMMMMMMMMWKo;..,lkXWMMMMMMNOo:.  .lOo. cXMXc",                      
            "                       .cONMMMMMMMMMMMMMMMMMMMMMMMMMMWX0xoodkKWMMMMMMMWXkl;'. .oNMK:",                     
            "                     .:0WMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWMMWNNWMMMMMMMMMMMWXOx0WWO,",                   
            "                    .xNMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMNKOkOKNWMMMNXNWMMMWXKNWKo.",                  
            "                   .kWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWXkdl:cOMMk'':lll;..',.",                  
            "                  .xWMMMMMMMWNXXKKKKKXXNWWMMMMMMMMMMMMMMMMMMMWK0XMMx.",                  
            "                  cNWNKOxoc:,'.........',;coxOKNMMMMMMMMMMMMMMMMMMMO' ",                   
            "                 .;c;'.                       .':oxkKWMMMMMMMMMMMMMNl",                   
            "                                                    .,lx0NWMMMMMMMMM0,",                   
            "                                                        ..;coxkkkkxxo' ",
            "",
            "",  

        };

        // Mostrar el arte ASCII en la consola
        Console.ForegroundColor = ConsoleColor.White;
        foreach (string line in asciiArt)
        {
            Console.WriteLine(line);
        }
        Console.ResetColor();
      
    }
  
}