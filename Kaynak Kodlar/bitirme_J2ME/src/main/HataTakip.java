package main;
/* MEHMET CAMBAZ
 *
 * HataTakip.java
 * 
 * Created on April 12, 2006, 11:17 PM
 */

import javax.microedition.midlet.*;
import javax.microedition.lcdui.*;
import kullaniciWS.KullaniciWSSoap_Stub;
import projeWS.ProjeWSSoap_Stub;
import hataWS.HataWSSoap_Stub;
import kullaniciWS.KullaniciWSSoap_Stub;

/**
 *
 * @author Mehmet
 */
public class HataTakip extends MIDlet implements CommandListener 
{
    
    /**
     * Creates a new instance of HataTakip
     */
    public HataTakip() {
        initialize();
    }
    
    private List islemListesi;//GEN-BEGIN:MVDFields
    private Command backCommand1;
    private Command okCommandProjeListele;
    private Command exitCommand1;
    private org.netbeans.microedition.lcdui.WaitScreen bekletmeEkraniListe;
    private Alert hata;
    private Command okCommandListeleCikis;
    private Form cozulmemisHataSayisi;
    private Command backCommand2;
    private Command okCommandHataSayisiAl;
    private Command backCommand3;
    private Form hataGonder;
    private Command backCommand4;
    private Command okCommandGonder;
    private Command okCommand5;
    private Command okCommand6;
    private org.netbeans.microedition.lcdui.WaitScreen bekletmeEkraniHataSayisi;
    private org.netbeans.microedition.lcdui.WaitScreen bekletmeEkraniIlkSoru;
    private TextField projeIsmiHataSayisi;
    private Form hataSayisiSonuc;
    private Command okCommand1;
    private Form soruGoster;
    private Command evetCmdItem;
    private Command hayirCmdItem;
    private org.netbeans.microedition.lcdui.SimpleTableModel simpleTableModel1;
    private Command okCommand2;
    private Command itemCommand3;
    private List projeler;
    private Command okCommand3;
    private StringItem hataSayisi;
    private Command exitCommand2;
    private Command backCommand5;
    private Command okCommand4;
    private TextField projeIsmiHataGonder;
    private StringItem lblSoru;
    private StringItem lblNot;
    private org.netbeans.microedition.lcdui.WaitScreen bekletmeEkraniEvetSonraki;
    private org.netbeans.microedition.lcdui.WaitScreen bekletmeEkraniHayirSonraki;
    private Form hataGondermeFormu;
    private TextField hataAciklama;
    private Command okCommand7;
    private org.netbeans.microedition.lcdui.WaitScreen bekletmeEkraniGonderim;
    private StringItem lblSoru1;
    private StringItem lblNot1;
    private Form hataGondermeSonuc;
    private Command okCommand8;
    private StringItem hataGondermeSonuc1;
    private org.netbeans.microedition.lcdui.WaitScreen bekletmeEkraniGiris;
    private Form girisFormu;
    private Command okCommand9;
    private TextField txtIsim;
    private TextField txtSifre;
    private Command exitCommand3;//GEN-END:MVDFields
    
//GEN-LINE:MVDMethods
    private ProjeWSSoap_Stub client = new ProjeWSSoap_Stub();
    private HataWSSoap_Stub client2 = new HataWSSoap_Stub();
    private KullaniciWSSoap_Stub client3 = new KullaniciWSSoap_Stub();
    

    //web servis methodlari donus degerleri
    private projeWS.ArrayOfString projeleriListele_returnValue;  
    private long projeyeAitCozulmemisHataSayisi_returnValue;         
    private hataWS.SoruBilgi ilkSoru_returnValue; 
    private hataWS.SoruBilgi sonraki_returnValue; 
    
    //proje ile ilgili bilgiler    
    private java.lang.String projeIsmi = "";
    private long soruId = -1;
    private long evetId = -1;
    private long hayirId = -1;
    private long oncekiId = -1;
    private int cevap = -1;
    private java.lang.String sonuc = "";
    
    //kullanici ile ilgili bilgiler
    private long yollayanId = 0;
    private boolean basari = false;
    private boolean sorumlu = false;
    
    //bekletme ekranlarinda yapilacak islem tanimlamalari
    private org.netbeans.microedition.util.SimpleCancellableTask projeleriListele_Task;      
    private org.netbeans.microedition.util.SimpleCancellableTask projeyeAitCozulmemisHataSayisi_Task;    
    private org.netbeans.microedition.util.SimpleCancellableTask ilkSoru_Task;
    private org.netbeans.microedition.util.SimpleCancellableTask evetSonraki_Task;
    private org.netbeans.microedition.util.SimpleCancellableTask hayirSonraki_Task;   
    private org.netbeans.microedition.util.SimpleCancellableTask gonder_Task;
    private org.netbeans.microedition.util.SimpleCancellableTask giris_Task;

/*********************giris islemleri ilgili methodlar BASLA*****************/     
    private void call_giris(java.lang.String isim, java.lang.String sifre) throws java.io.IOException {
        basari = client3.giris(isim, sifre);
        if(basari) {
            bekletmeEkraniGiris.setNextDisplayable(get_islemListesi());
            yollayanId = client3.idGetir(isim);
            java.lang.String tip = client3.tipGetir(isim);
            sorumlu = tip.equals("sorumlu");
            if(!sorumlu)
                islemListesi.delete(2);
        }
        else
            bekletmeEkraniGiris.setNextDisplayable(get_girisFormu());
    }
    
    
    public org.netbeans.microedition.util.SimpleCancellableTask get_giris_Task() {
        if (giris_Task == null) {                       
            // Insert pre-init code here
            giris_Task = new org.netbeans.microedition.util.SimpleCancellableTask();                        
            giris_Task.setExecutable(new org.netbeans.microedition.util.Executable() {
            public void execute() throws Exception {
                    try {
                        if((txtIsim.getString() != "") && (txtSifre.getString() != "")) {
                            call_giris(txtIsim.getString(), txtSifre.getString());
                        }
                        else
                            bekletmeEkraniGiris.setNextDisplayable(get_girisFormu());
                    } catch (java.io.IOException ioe) {
                        throw new RuntimeException(ioe.getMessage());
                    }                                     
                }
            });                      
        }                       
        return giris_Task;
    }
/*********************giris islemleri ilgili methodlar SON*****************/      
    
    
/*********************projeleriListele() ilgili methodlar BASLA*****************/    
    //projeleriListele() web servis methodunu ça??r?r
    private void call_projeleriListele() throws java.io.IOException {
        projeleriListele_returnValue = client.projeleriListele();
    }
    
    //dönmü? de?eri listeye eklenmesi için haz?r hale getirir
    private void set_projeleriListele_OutputValues() {
        if ( projeleriListele_returnValue != null) {
            set_projeleriListele_string_OutputValues(projeleriListele_returnValue.getString());
        } else {
            projeler.deleteAll();
        }
    }    
    
    //listeyi doldurur
    private void set_projeleriListele_string_OutputValues(java.lang.String[] arg) {
        projeler.deleteAll();
        if ( arg != null) {
            for (int i = 0; i < arg.length; i++) {
                projeler.append(arg[i],null);
            }
        }
    }    
 
    //bekleme an?nda web servise ba?lanarak gerekli bilgilerin al?nmas?n? sa?layacak i?lem i yarat?r
    public org.netbeans.microedition.util.SimpleCancellableTask get_projeleriListele_Task() {
        if (projeleriListele_Task == null) {
            // Insert pre-init code here
            projeleriListele_Task = new org.netbeans.microedition.util.SimpleCancellableTask();
            projeleriListele_Task.setExecutable(new org.netbeans.microedition.util.Executable() {
                public void execute() throws Exception {
                    try {
                        call_projeleriListele();
                    } catch (java.io.IOException ioe) {
                        throw new RuntimeException(ioe.getMessage());
                    }
                    set_projeleriListele_OutputValues();                                        
                }
            });
        }
        return projeleriListele_Task;
    }   
/*********************projeleriListele() ilgili methodlar SON*****************/
    
    

/*********************projeyeAitCozulmemisHataSayisi() ile ilgili methodlar BAS*****************/    
    // projeyeAitCozulmemisHataSayisi web servisi methodunu ça??r?r
    private void call_projeyeAitCozulmemisHataSayisi() throws java.io.IOException {
        projeIsmi = projeIsmiHataSayisi.getString();
        projeyeAitCozulmemisHataSayisi_returnValue = client.projeyeAitCozulmemisHataSayisi(projeIsmi);
    }
    
    // web servisi sonucuna göre ç?kt?y? ayarlar
    private void set_projeyeAitCozulmemisHataSayisi_OutputValues() {
        hataSayisi.setLabel("Proje: "+projeIsmi);
        hataSayisi.setText("\n"+projeyeAitCozulmemisHataSayisi_returnValue);
    } 
    
    // beklerken yap?lacak i?lemi tan?mlar
    public org.netbeans.microedition.util.SimpleCancellableTask get_projeyeAitCozulmemisHataSayisi_Task() {
        if (projeyeAitCozulmemisHataSayisi_Task == null) {                       
            // Insert pre-init code here
            projeyeAitCozulmemisHataSayisi_Task = new org.netbeans.microedition.util.SimpleCancellableTask();                        
            projeyeAitCozulmemisHataSayisi_Task.setExecutable(new org.netbeans.microedition.util.Executable() {
                public void execute() throws Exception {
                    try {
                        call_projeyeAitCozulmemisHataSayisi();
                    } catch (java.io.IOException ioe) {
                        throw new RuntimeException(ioe.getMessage());
                    }
                    set_projeyeAitCozulmemisHataSayisi_OutputValues();                                        
                }
            });
        }
        return projeyeAitCozulmemisHataSayisi_Task;
    }  
/*********************projeyeAitCozulmemisHataSayisi() ile ilgili methodlar SON*****************/                             

    
    
    
/*********************ilkSoru() ilgili methodlar BASLA*****************/    
// method calling the generated method
    private void call_ilkSoru() throws java.io.IOException {
        projeIsmi = projeIsmiHataGonder.getString();
        ilkSoru_returnValue = client2.ilkSoru(projeIsmi);
    }
    
    // method for setting output values
    private void set_ilkSoru_OutputValues() {
        if ( ilkSoru_returnValue != null) {
            soruId = ilkSoru_returnValue.getId();
            if(soruId != 0)
            {
                lblSoru.setText(ilkSoru_returnValue.getSoru());
                lblNot.setText(ilkSoru_returnValue.getKNot());
                evetId = ilkSoru_returnValue.getEvetId();
                hayirId = ilkSoru_returnValue.getHayirId();
            }
            else
            {
                lblSoru.setText("Bu projeye daha soru eklenmemis");
            }
        } else {
            soruId = -1;
            lblSoru.setText("???null???");
            lblNot.setText("???null???");
            evetId = -1;
            hayirId = -1;
        }
    }

    // beklerken yap?lacak i?lemi tan?mlar
    public org.netbeans.microedition.util.SimpleCancellableTask get_ilkSoru_Task() {
        if (ilkSoru_Task == null) {                       
            // Insert pre-init code here
            ilkSoru_Task = new org.netbeans.microedition.util.SimpleCancellableTask();                        
            ilkSoru_Task.setExecutable(new org.netbeans.microedition.util.Executable() {
                public void execute() throws Exception {
                    try {
                        call_ilkSoru();
                    } catch (java.io.IOException ioe) {
                        throw new RuntimeException(ioe.getMessage());
                    }
                    set_ilkSoru_OutputValues();                                     
                }
            });                      
        }                       
        return ilkSoru_Task;
    }      
/*********************ilkSoru() ilgili methodlar SON*****************/    

    
    

/*********************sonraki() ilgili methodlar BASLA*****************/    
    //sonraki() web servisi methodunu ça??r
    private void call_sonraki(long sonrakiId) throws java.io.IOException {
        sonraki_returnValue = client2.sonraki(sonrakiId);
    }
    
    //method ça??r?ld?ktan sonra ç?kt?lar? düzenler
    private void set_sonraki_OutputValues() {
        if ( sonraki_returnValue != null) {
            soruId = sonraki_returnValue.getId();
            if(soruId != 0)
            {
                lblSoru.setText(sonraki_returnValue.getSoru());
                lblNot.setText(sonraki_returnValue.getKNot());
                evetId = sonraki_returnValue.getEvetId();
                hayirId = sonraki_returnValue.getHayirId();
            }
            else
            {
                sorulari_sil();                
            }
        } else {
            soruId = -1;
            lblSoru.setText("???null???");
            lblNot.setText("???null???");
            evetId = -1;
            hayirId = -1;
        }

    }
    
    // beklerken yap?lacak i?lemi tan?mlar
    public org.netbeans.microedition.util.SimpleCancellableTask get_evetsonraki_Task() {
        if (evetSonraki_Task == null) {                       
            // Insert pre-init code here
            evetSonraki_Task = new org.netbeans.microedition.util.SimpleCancellableTask();                        
            evetSonraki_Task.setExecutable(new org.netbeans.microedition.util.Executable() {
                public void execute() throws Exception {
                    try {
                        cevap = 1;
                        if(evetId != 0){
                            oncekiId = evetId;                            
                            call_sonraki(evetId);
                        }
                        else
                            bekletmeEkraniEvetSonraki.setNextDisplayable(get_hataGondermeFormu());
                    } catch (java.io.IOException ioe) {
                        throw new RuntimeException(ioe.getMessage());
                    }
                    set_sonraki_OutputValues();                                        
                }
            });                      
        }                       
        return evetSonraki_Task;
    }                       
    
    // beklerken yap?lacak i?lemi tan?mlar
    public org.netbeans.microedition.util.SimpleCancellableTask get_hayirsonraki_Task() {
        if (hayirSonraki_Task == null) {                       
            // Insert pre-init code here
            hayirSonraki_Task = new org.netbeans.microedition.util.SimpleCancellableTask();                        
            hayirSonraki_Task.setExecutable(new org.netbeans.microedition.util.Executable() {
                public void execute() throws Exception {
                    try {
                        cevap = 0;
                        if(hayirId != 0){
                            oncekiId = hayirId;                            
                            call_sonraki(hayirId);
                        }
                        else
                            bekletmeEkraniHayirSonraki.setNextDisplayable(get_hataGondermeFormu());
                    } catch (java.io.IOException ioe) {
                        throw new RuntimeException(ioe.getMessage());
                    }
                    set_sonraki_OutputValues();                                       
                }
            });                      
        }                       
        return hayirSonraki_Task;
    }   
/*********************sonraki() ilgili methodlar SON*****************/       
                       
    
    
                     

/*********************gonder() ilgili methodlar BASLA*****************/   
    //gonder() web servisi methodunu cagirir
    private void call_gonder() throws java.io.IOException
    {
        sonuc = client2.gonder(projeIsmi,oncekiId,cevap,hataAciklama.getString(),yollayanId);
    }
     
    //web servisi methodunun sonucuna gore ciktilari ayarlar
    private void set_gonder_OutputValues()
    {
        hataGondermeSonuc1.setLabel("Proje: "+projeIsmi+"\n");
        hataGondermeSonuc1.setText(sonuc);
        
        proje_bilgilerini_temizle();
    }
    
    // beklerken yap?lacak i?lemi tan?mlar
    public org.netbeans.microedition.util.SimpleCancellableTask get_gonder_Task() {
        if (gonder_Task == null) {                       
            // Insert pre-init code here
            gonder_Task = new org.netbeans.microedition.util.SimpleCancellableTask();                        
            gonder_Task.setExecutable(new org.netbeans.microedition.util.Executable() {
                public void execute() throws Exception {
                    try {
                        call_gonder();
                    } catch (java.io.IOException ioe) {
                        throw new RuntimeException(ioe.getMessage());
                    }
                    set_gonder_OutputValues();                                      
                }
            });                      
        }                       
        return gonder_Task;
    }        
/*********************gonder() ilgili methodlar SON*****************/        
       
    private void sorulari_sil()
    {
        lblSoru.setText("");
        lblNot.setText("");
    }
    
    private void proje_bilgilerini_temizle()
    {
        projeIsmi = "";
        soruId = -1;
        evetId = -1;
        hayirId = -1;
        oncekiId = -1;
        cevap = -1;
        sonuc = "";
    }

    
    
       
       
    
    /** Called by the system to indicate that a command has been invoked on a particular displayable.//GEN-BEGIN:MVDCABegin
     * @param command the Command that ws invoked
     * @param displayable the Displayable on which the command was invoked
     */
    public void commandAction(Command command, Displayable displayable) {//GEN-END:MVDCABegin
    // Insert global pre-action code here
        if (displayable == islemListesi) {//GEN-BEGIN:MVDCABody
            if (command == islemListesi.SELECT_COMMAND) {
                switch (get_islemListesi().getSelectedIndex()) {
                    case 0://GEN-END:MVDCABody
                        // Insert pre-action code here
                        getDisplay().setCurrent(get_bekletmeEkraniListe());//GEN-LINE:MVDCAAction6
                        // Insert post-action code here
                        break;//GEN-BEGIN:MVDCACase6
                    case 2://GEN-END:MVDCACase6
                        // Insert pre-action code here
                        getDisplay().setCurrent(get_cozulmemisHataSayisi());//GEN-LINE:MVDCAAction8
                        // Insert post-action code here
                        break;//GEN-BEGIN:MVDCACase8
                    case 1://GEN-END:MVDCACase8
                        // Insert pre-action code here
                        getDisplay().setCurrent(get_hataGonder());//GEN-LINE:MVDCAAction10
                        // Insert post-action code here
                        break;//GEN-BEGIN:MVDCACase10
                }
            } else if (command == exitCommand1) {//GEN-END:MVDCACase10
                // Insert pre-action code here
                exitMIDlet();//GEN-LINE:MVDCAAction17
                // Insert post-action code here
            } else if (command == okCommand6) {//GEN-LINE:MVDCACase17
                // Insert pre-action code here
                // Do nothing//GEN-LINE:MVDCAAction40
                // Insert post-action code here
            }//GEN-BEGIN:MVDCACase40
        } else if (displayable == hataGonder) {
            if (command == backCommand4) {//GEN-END:MVDCACase40
                // Insert pre-action code here
                getDisplay().setCurrent(get_islemListesi());//GEN-LINE:MVDCAAction35
                // Insert post-action code here
            } else if (command == okCommandGonder) {//GEN-LINE:MVDCACase35
                // Insert pre-action code here
                getDisplay().setCurrent(get_bekletmeEkraniIlkSoru());//GEN-LINE:MVDCAAction37
                // Insert post-action code here
            }//GEN-BEGIN:MVDCACase37
        } else if (displayable == cozulmemisHataSayisi) {
            if (command == backCommand3) {//GEN-END:MVDCACase37
                // Insert pre-action code here
                getDisplay().setCurrent(get_islemListesi());//GEN-LINE:MVDCAAction32
                // Insert post-action code here
            } else if (command == okCommandHataSayisiAl) {//GEN-LINE:MVDCACase32
                // Insert pre-action code here
                getDisplay().setCurrent(get_bekletmeEkraniHataSayisi());//GEN-LINE:MVDCAAction30
                // Insert post-action code here
            }//GEN-BEGIN:MVDCACase30
        } else if (displayable == soruGoster) {
            if (command == evetCmdItem) {//GEN-END:MVDCACase30
                // Insert pre-action code here
                getDisplay().setCurrent(get_bekletmeEkraniEvetSonraki());//GEN-LINE:MVDCAAction53
                // Insert post-action code here
            } else if (command == hayirCmdItem) {//GEN-LINE:MVDCACase53
                // Insert pre-action code here
                getDisplay().setCurrent(get_bekletmeEkraniHayirSonraki());//GEN-LINE:MVDCAAction55
                // Insert post-action code here
            } else if (command == exitCommand2) {//GEN-LINE:MVDCACase55
                // Insert pre-action code here
                getDisplay().setCurrent(get_islemListesi());//GEN-LINE:MVDCAAction76
                // Insert post-action code here
            }//GEN-BEGIN:MVDCACase76
        } else if (displayable == hataSayisiSonuc) {
            if (command == okCommand1) {//GEN-END:MVDCACase76
                // Insert pre-action code here
                getDisplay().setCurrent(get_islemListesi());//GEN-LINE:MVDCAAction50
                // Insert post-action code here
            }//GEN-BEGIN:MVDCACase50
        } else if (displayable == projeler) {
            if (command == okCommand3) {//GEN-END:MVDCACase50
                // Insert pre-action code here
                getDisplay().setCurrent(get_islemListesi());//GEN-LINE:MVDCAAction73
                // Insert post-action code here
            }//GEN-BEGIN:MVDCACase73
        } else if (displayable == hataGondermeFormu) {
            if (command == okCommand7) {//GEN-END:MVDCACase73
                   // Insert pre-action code here
                getDisplay().setCurrent(get_bekletmeEkraniGonderim());//GEN-LINE:MVDCAAction98
                   // Insert post-action code here
            }//GEN-BEGIN:MVDCACase98
        } else if (displayable == hataGondermeSonuc) {
            if (command == okCommand8) {//GEN-END:MVDCACase98
                // Insert pre-action code here
                getDisplay().setCurrent(get_islemListesi());//GEN-LINE:MVDCAAction115
                // Insert post-action code here
            }//GEN-BEGIN:MVDCACase115
        } else if (displayable == girisFormu) {
            if (command == okCommand9) {//GEN-END:MVDCACase115

                getDisplay().setCurrent(get_bekletmeEkraniGiris());//GEN-LINE:MVDCAAction127

            } else if (command == exitCommand3) {//GEN-LINE:MVDCACase127
                // Insert pre-action code here
                exitMIDlet();//GEN-LINE:MVDCAAction134
                // Insert post-action code here
            }//GEN-BEGIN:MVDCACase134
        }//GEN-END:MVDCACase134
    // Insert global post-action code here
}//GEN-LINE:MVDCAEnd

    /** This method initializes UI of the application.//GEN-BEGIN:MVDInitBegin
     */
    private void initialize() {//GEN-END:MVDInitBegin
        // Insert pre-init code here
        getDisplay().setCurrent(get_girisFormu());//GEN-LINE:MVDInitInit
        // Insert post-init code here
    }//GEN-LINE:MVDInitEnd
    
    /**
     * This method should return an instance of the display.
     */
    public Display getDisplay() {//GEN-FIRST:MVDGetDisplay
        return Display.getDisplay(this);
    }//GEN-LAST:MVDGetDisplay
    
    /**
     * This method should exit the midlet.
     */
    public void exitMIDlet() {//GEN-FIRST:MVDExitMidlet
        getDisplay().setCurrent(null);
        destroyApp(true);
        notifyDestroyed();
    }//GEN-LAST:MVDExitMidlet
    /** This method returns instance for islemListesi component and should be called instead of accessing islemListesi field directly.//GEN-BEGIN:MVDGetBegin3
     * @return Instance for islemListesi component
     */
    public List get_islemListesi() {
        if (islemListesi == null) {//GEN-END:MVDGetBegin3
            // Insert pre-init code here
            islemListesi = new List("\u0130slem Seciniz", Choice.IMPLICIT, new String[] {//GEN-BEGIN:MVDGetInit3
                "Projelerin listesine bak",
                "Hata gonder",
                "Cozulmemis hata sayisini al"
            }, new Image[] {
                null,
                null,
                null
            });
            islemListesi.addCommand(get_exitCommand1());
            islemListesi.setCommandListener(this);
            islemListesi.setSelectedFlags(new boolean[] {
                false,
                false,
                false
            });//GEN-END:MVDGetInit3
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd3
        return islemListesi;
    }//GEN-END:MVDGetEnd3
    /** This method returns instance for backCommand1 component and should be called instead of accessing backCommand1 field directly.//GEN-BEGIN:MVDGetBegin12
     * @return Instance for backCommand1 component
     */
    public Command get_backCommand1() {
        if (backCommand1 == null) {//GEN-END:MVDGetBegin12
            // Insert pre-init code here
            backCommand1 = new Command("Back", Command.BACK, 1);//GEN-LINE:MVDGetInit12
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd12
        return backCommand1;
    }//GEN-END:MVDGetEnd12

    /** This method returns instance for okCommandProjeListele component and should be called instead of accessing okCommandProjeListele field directly.//GEN-BEGIN:MVDGetBegin14
     * @return Instance for okCommandProjeListele component
     */
    public Command get_okCommandProjeListele() {
        if (okCommandProjeListele == null) {//GEN-END:MVDGetBegin14
            // Insert pre-init code here
            okCommandProjeListele = new Command("Ok", Command.OK, 1);//GEN-LINE:MVDGetInit14
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd14
        return okCommandProjeListele;
    }//GEN-END:MVDGetEnd14

    /** This method returns instance for exitCommand1 component and should be called instead of accessing exitCommand1 field directly.//GEN-BEGIN:MVDGetBegin16
     * @return Instance for exitCommand1 component
     */
    public Command get_exitCommand1() {
        if (exitCommand1 == null) {//GEN-END:MVDGetBegin16
            // Insert pre-init code here
            exitCommand1 = new Command("Exit", Command.EXIT, 1);//GEN-LINE:MVDGetInit16
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd16
        return exitCommand1;
    }//GEN-END:MVDGetEnd16
    /** This method returns instance for bekletmeEkraniListe component and should be called instead of accessing bekletmeEkraniListe field directly.//GEN-BEGIN:MVDGetBegin19
     * @return Instance for bekletmeEkraniListe component
     */
    public org.netbeans.microedition.lcdui.WaitScreen get_bekletmeEkraniListe() {
        if (bekletmeEkraniListe == null) {//GEN-END:MVDGetBegin19

            bekletmeEkraniListe = new org.netbeans.microedition.lcdui.WaitScreen(getDisplay());//GEN-BEGIN:MVDGetInit19
            bekletmeEkraniListe.setFailureDisplayable(get_hata(), get_islemListesi());
            bekletmeEkraniListe.setText("Sunucudan liste aliniyor, lutfen bekleyiniz...");
            bekletmeEkraniListe.setNextDisplayable(get_projeler());//GEN-END:MVDGetInit19
            bekletmeEkraniListe.setTask(get_projeleriListele_Task());
// Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd19
        return bekletmeEkraniListe;
    }//GEN-END:MVDGetEnd19

    /** This method returns instance for hata component and should be called instead of accessing hata field directly.//GEN-BEGIN:MVDGetBegin22
     * @return Instance for hata component
     */
    public Alert get_hata() {
        if (hata == null) {//GEN-END:MVDGetBegin22
            // Insert pre-init code here
            hata = new Alert(null, "<Enter Text>", null, AlertType.INFO);//GEN-BEGIN:MVDGetInit22
            hata.setTimeout(-2);//GEN-END:MVDGetInit22
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd22
        return hata;
    }//GEN-END:MVDGetEnd22
    /** This method returns instance for okCommandListeleCikis component and should be called instead of accessing okCommandListeleCikis field directly.//GEN-BEGIN:MVDGetBegin25
     * @return Instance for okCommandListeleCikis component
     */
    public Command get_okCommandListeleCikis() {
        if (okCommandListeleCikis == null) {//GEN-END:MVDGetBegin25
            // Insert pre-init code here
            okCommandListeleCikis = new Command("Ok", Command.OK, 1);//GEN-LINE:MVDGetInit25
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd25
        return okCommandListeleCikis;
    }//GEN-END:MVDGetEnd25

    /** This method returns instance for cozulmemisHataSayisi component and should be called instead of accessing cozulmemisHataSayisi field directly.//GEN-BEGIN:MVDGetBegin27
     * @return Instance for cozulmemisHataSayisi component
     */
    public Form get_cozulmemisHataSayisi() {
        if (cozulmemisHataSayisi == null) {//GEN-END:MVDGetBegin27
            // Insert pre-init code here
            cozulmemisHataSayisi = new Form(null, new Item[] {get_projeIsmiHataSayisi()});//GEN-BEGIN:MVDGetInit27
            cozulmemisHataSayisi.addCommand(get_okCommandHataSayisiAl());
            cozulmemisHataSayisi.addCommand(get_backCommand3());
            cozulmemisHataSayisi.setCommandListener(this);//GEN-END:MVDGetInit27
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd27
        return cozulmemisHataSayisi;
    }//GEN-END:MVDGetEnd27

    /** This method returns instance for backCommand2 component and should be called instead of accessing backCommand2 field directly.//GEN-BEGIN:MVDGetBegin28
     * @return Instance for backCommand2 component
     */
    public Command get_backCommand2() {
        if (backCommand2 == null) {//GEN-END:MVDGetBegin28
            // Insert pre-init code here
            backCommand2 = new Command("Back", Command.BACK, 1);//GEN-LINE:MVDGetInit28
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd28
        return backCommand2;
    }//GEN-END:MVDGetEnd28

    /** This method returns instance for okCommandHataSayisiAl component and should be called instead of accessing okCommandHataSayisiAl field directly.//GEN-BEGIN:MVDGetBegin29
     * @return Instance for okCommandHataSayisiAl component
     */
    public Command get_okCommandHataSayisiAl() {
        if (okCommandHataSayisiAl == null) {//GEN-END:MVDGetBegin29
            // Insert pre-init code here
            okCommandHataSayisiAl = new Command("Ok", Command.OK, 1);//GEN-LINE:MVDGetInit29
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd29
        return okCommandHataSayisiAl;
    }//GEN-END:MVDGetEnd29

    /** This method returns instance for backCommand3 component and should be called instead of accessing backCommand3 field directly.//GEN-BEGIN:MVDGetBegin31
     * @return Instance for backCommand3 component
     */
    public Command get_backCommand3() {
        if (backCommand3 == null) {//GEN-END:MVDGetBegin31
            // Insert pre-init code here
            backCommand3 = new Command("Back", Command.BACK, 1);//GEN-LINE:MVDGetInit31
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd31
        return backCommand3;
    }//GEN-END:MVDGetEnd31

    /** This method returns instance for hataGonder component and should be called instead of accessing hataGonder field directly.//GEN-BEGIN:MVDGetBegin33
     * @return Instance for hataGonder component
     */
    public Form get_hataGonder() {
        if (hataGonder == null) {//GEN-END:MVDGetBegin33
            // Insert pre-init code here
            hataGonder = new Form(null, new Item[] {get_projeIsmiHataGonder()});//GEN-BEGIN:MVDGetInit33
            hataGonder.addCommand(get_backCommand4());
            hataGonder.addCommand(get_okCommandGonder());
            hataGonder.setCommandListener(this);//GEN-END:MVDGetInit33
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd33
        return hataGonder;
    }//GEN-END:MVDGetEnd33

    /** This method returns instance for backCommand4 component and should be called instead of accessing backCommand4 field directly.//GEN-BEGIN:MVDGetBegin34
     * @return Instance for backCommand4 component
     */
    public Command get_backCommand4() {
        if (backCommand4 == null) {//GEN-END:MVDGetBegin34
            // Insert pre-init code here
            backCommand4 = new Command("Back", Command.BACK, 1);//GEN-LINE:MVDGetInit34
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd34
        return backCommand4;
    }//GEN-END:MVDGetEnd34

    /** This method returns instance for okCommandGonder component and should be called instead of accessing okCommandGonder field directly.//GEN-BEGIN:MVDGetBegin36
     * @return Instance for okCommandGonder component
     */
    public Command get_okCommandGonder() {
        if (okCommandGonder == null) {//GEN-END:MVDGetBegin36
            // Insert pre-init code here
            okCommandGonder = new Command("Ok", Command.OK, 1);//GEN-LINE:MVDGetInit36
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd36
        return okCommandGonder;
    }//GEN-END:MVDGetEnd36

    /** This method returns instance for okCommand5 component and should be called instead of accessing okCommand5 field directly.//GEN-BEGIN:MVDGetBegin38
     * @return Instance for okCommand5 component
     */
    public Command get_okCommand5() {
        if (okCommand5 == null) {//GEN-END:MVDGetBegin38
            // Insert pre-init code here
            okCommand5 = new Command("Ok", Command.OK, 1);//GEN-LINE:MVDGetInit38
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd38
        return okCommand5;
    }//GEN-END:MVDGetEnd38

    /** This method returns instance for okCommand6 component and should be called instead of accessing okCommand6 field directly.//GEN-BEGIN:MVDGetBegin39
     * @return Instance for okCommand6 component
     */
    public Command get_okCommand6() {
        if (okCommand6 == null) {//GEN-END:MVDGetBegin39
            // Insert pre-init code here
            okCommand6 = new Command("Ok", Command.OK, 1);//GEN-LINE:MVDGetInit39
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd39
        return okCommand6;
    }//GEN-END:MVDGetEnd39

    /** This method returns instance for bekletmeEkraniHataSayisi component and should be called instead of accessing bekletmeEkraniHataSayisi field directly.//GEN-BEGIN:MVDGetBegin41
     * @return Instance for bekletmeEkraniHataSayisi component
     */
    public org.netbeans.microedition.lcdui.WaitScreen get_bekletmeEkraniHataSayisi() {
        if (bekletmeEkraniHataSayisi == null) {//GEN-END:MVDGetBegin41
            // Insert pre-init code here
            bekletmeEkraniHataSayisi = new org.netbeans.microedition.lcdui.WaitScreen(getDisplay());//GEN-BEGIN:MVDGetInit41
            bekletmeEkraniHataSayisi.setFailureDisplayable(get_hata(), get_islemListesi());
            bekletmeEkraniHataSayisi.setText("Sunucudan sayi aliniyor, lutfen bekleyiniz...");
            bekletmeEkraniHataSayisi.setNextDisplayable(get_hataSayisiSonuc());//GEN-END:MVDGetInit41
            bekletmeEkraniHataSayisi.setTask(get_projeyeAitCozulmemisHataSayisi_Task());
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd41
        return bekletmeEkraniHataSayisi;
    }//GEN-END:MVDGetEnd41

    /** This method returns instance for bekletmeEkraniIlkSoru component and should be called instead of accessing bekletmeEkraniIlkSoru field directly.//GEN-BEGIN:MVDGetBegin44
     * @return Instance for bekletmeEkraniIlkSoru component
     */
    public org.netbeans.microedition.lcdui.WaitScreen get_bekletmeEkraniIlkSoru() {
        if (bekletmeEkraniIlkSoru == null) {//GEN-END:MVDGetBegin44
            // Insert pre-init code here
            bekletmeEkraniIlkSoru = new org.netbeans.microedition.lcdui.WaitScreen(getDisplay());//GEN-BEGIN:MVDGetInit44
            bekletmeEkraniIlkSoru.setFailureDisplayable(get_hata(), get_islemListesi());
            bekletmeEkraniIlkSoru.setText("Sunucuya baglaniliyor, lutfen bekleyiniz...");
            bekletmeEkraniIlkSoru.setNextDisplayable(get_soruGoster());//GEN-END:MVDGetInit44
            bekletmeEkraniIlkSoru.setTask(get_ilkSoru_Task());
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd44
        return bekletmeEkraniIlkSoru;
    }//GEN-END:MVDGetEnd44

    /** This method returns instance for projeIsmiHataSayisi component and should be called instead of accessing projeIsmiHataSayisi field directly.//GEN-BEGIN:MVDGetBegin47
     * @return Instance for projeIsmiHataSayisi component
     */
    public TextField get_projeIsmiHataSayisi() {
        if (projeIsmiHataSayisi == null) {//GEN-END:MVDGetBegin47
            // Insert pre-init code here
            projeIsmiHataSayisi = new TextField("Proje ismini giriniz:", "", 120, TextField.ANY);//GEN-LINE:MVDGetInit47
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd47
        return projeIsmiHataSayisi;
    }//GEN-END:MVDGetEnd47

    /** This method returns instance for hataSayisiSonuc component and should be called instead of accessing hataSayisiSonuc field directly.//GEN-BEGIN:MVDGetBegin48
     * @return Instance for hataSayisiSonuc component
     */
    public Form get_hataSayisiSonuc() {
        if (hataSayisiSonuc == null) {//GEN-END:MVDGetBegin48
            // Insert pre-init code here
            hataSayisiSonuc = new Form("Cozulmemis hata sayisi", new Item[] {get_hataSayisi()});//GEN-BEGIN:MVDGetInit48
            hataSayisiSonuc.addCommand(get_okCommand1());
            hataSayisiSonuc.setCommandListener(this);//GEN-END:MVDGetInit48
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd48
        return hataSayisiSonuc;
    }//GEN-END:MVDGetEnd48

    /** This method returns instance for okCommand1 component and should be called instead of accessing okCommand1 field directly.//GEN-BEGIN:MVDGetBegin49
     * @return Instance for okCommand1 component
     */
    public Command get_okCommand1() {
        if (okCommand1 == null) {//GEN-END:MVDGetBegin49
            // Insert pre-init code here
            okCommand1 = new Command("Ok", Command.OK, 1);//GEN-LINE:MVDGetInit49
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd49
        return okCommand1;
    }//GEN-END:MVDGetEnd49

    /** This method returns instance for soruGoster component and should be called instead of accessing soruGoster field directly.//GEN-BEGIN:MVDGetBegin51
     * @return Instance for soruGoster component
     */
    public Form get_soruGoster() {
        if (soruGoster == null) {//GEN-END:MVDGetBegin51
            // Insert pre-init code here
            soruGoster = new Form("Soru sorma ekrani", new Item[] {//GEN-BEGIN:MVDGetInit51
                get_lblSoru(),
                get_lblNot()
            });
            soruGoster.addCommand(get_evetCmdItem());
            soruGoster.addCommand(get_hayirCmdItem());
            soruGoster.addCommand(get_exitCommand2());
            soruGoster.setCommandListener(this);//GEN-END:MVDGetInit51
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd51
        return soruGoster;
    }//GEN-END:MVDGetEnd51

    /** This method returns instance for evetCmdItem component and should be called instead of accessing evetCmdItem field directly.//GEN-BEGIN:MVDGetBegin52
     * @return Instance for evetCmdItem component
     */
    public Command get_evetCmdItem() {
        if (evetCmdItem == null) {//GEN-END:MVDGetBegin52
            // Insert pre-init code here
            evetCmdItem = new Command("Evet", Command.ITEM, 1);//GEN-LINE:MVDGetInit52
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd52
        return evetCmdItem;
    }//GEN-END:MVDGetEnd52

    /** This method returns instance for hayirCmdItem component and should be called instead of accessing hayirCmdItem field directly.//GEN-BEGIN:MVDGetBegin54
     * @return Instance for hayirCmdItem component
     */
    public Command get_hayirCmdItem() {
        if (hayirCmdItem == null) {//GEN-END:MVDGetBegin54
            // Insert pre-init code here
            hayirCmdItem = new Command("Hayir", Command.ITEM, 1);//GEN-LINE:MVDGetInit54
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd54
        return hayirCmdItem;
    }//GEN-END:MVDGetEnd54

    /** This method returns instance for simpleTableModel1 component and should be called instead of accessing simpleTableModel1 field directly.//GEN-BEGIN:MVDGetBegin62
     * @return Instance for simpleTableModel1 component
     */
    public org.netbeans.microedition.lcdui.SimpleTableModel get_simpleTableModel1() {
        if (simpleTableModel1 == null) {//GEN-END:MVDGetBegin62
            // Insert pre-init code here
            simpleTableModel1 = new org.netbeans.microedition.lcdui.SimpleTableModel();//GEN-LINE:MVDGetInit62
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd62
        return simpleTableModel1;
    }//GEN-END:MVDGetEnd62

    /** This method returns instance for okCommand2 component and should be called instead of accessing okCommand2 field directly.//GEN-BEGIN:MVDGetBegin63
     * @return Instance for okCommand2 component
     */
    public Command get_okCommand2() {
        if (okCommand2 == null) {//GEN-END:MVDGetBegin63
            // Insert pre-init code here
            okCommand2 = new Command("Ok", Command.OK, 1);//GEN-LINE:MVDGetInit63
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd63
        return okCommand2;
    }//GEN-END:MVDGetEnd63

    /** This method returns instance for itemCommand3 component and should be called instead of accessing itemCommand3 field directly.//GEN-BEGIN:MVDGetBegin68
     * @return Instance for itemCommand3 component
     */
    public Command get_itemCommand3() {
        if (itemCommand3 == null) {//GEN-END:MVDGetBegin68
            // Insert pre-init code here
            itemCommand3 = new Command("Item", Command.ITEM, 1);//GEN-LINE:MVDGetInit68
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd68
        return itemCommand3;
    }//GEN-END:MVDGetEnd68

    /** This method returns instance for projeler component and should be called instead of accessing projeler field directly.//GEN-BEGIN:MVDGetBegin70
     * @return Instance for projeler component
     */
    public List get_projeler() {
        if (projeler == null) {//GEN-END:MVDGetBegin70
            // Insert pre-init code here
            projeler = new List("Mevcut projeler", Choice.IMPLICIT, new String[0], new Image[0]);//GEN-BEGIN:MVDGetInit70
            projeler.addCommand(get_okCommand3());
            projeler.setCommandListener(this);
            projeler.setSelectedFlags(new boolean[0]);//GEN-END:MVDGetInit70
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd70
        return projeler;
    }//GEN-END:MVDGetEnd70

    /** This method returns instance for okCommand3 component and should be called instead of accessing okCommand3 field directly.//GEN-BEGIN:MVDGetBegin72
     * @return Instance for okCommand3 component
     */
    public Command get_okCommand3() {
        if (okCommand3 == null) {//GEN-END:MVDGetBegin72
            // Insert pre-init code here
            okCommand3 = new Command("Ok", Command.OK, 1);//GEN-LINE:MVDGetInit72
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd72
        return okCommand3;
    }//GEN-END:MVDGetEnd72

    /** This method returns instance for hataSayisi component and should be called instead of accessing hataSayisi field directly.//GEN-BEGIN:MVDGetBegin74
     * @return Instance for hataSayisi component
     */
    public StringItem get_hataSayisi() {
        if (hataSayisi == null) {//GEN-END:MVDGetBegin74
            // Insert pre-init code here
            hataSayisi = new StringItem("", "");//GEN-LINE:MVDGetInit74
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd74
        return hataSayisi;
    }//GEN-END:MVDGetEnd74

    /** This method returns instance for exitCommand2 component and should be called instead of accessing exitCommand2 field directly.//GEN-BEGIN:MVDGetBegin75
     * @return Instance for exitCommand2 component
     */
    public Command get_exitCommand2() {
        if (exitCommand2 == null) {//GEN-END:MVDGetBegin75
            // Insert pre-init code here
            exitCommand2 = new Command("Exit", Command.EXIT, 1);//GEN-LINE:MVDGetInit75
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd75
        return exitCommand2;
    }//GEN-END:MVDGetEnd75

    /** This method returns instance for backCommand5 component and should be called instead of accessing backCommand5 field directly.//GEN-BEGIN:MVDGetBegin78
     * @return Instance for backCommand5 component
     */
    public Command get_backCommand5() {
        if (backCommand5 == null) {//GEN-END:MVDGetBegin78
            // Insert pre-init code here
            backCommand5 = new Command("Back", Command.BACK, 1);//GEN-LINE:MVDGetInit78
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd78
        return backCommand5;
    }//GEN-END:MVDGetEnd78

    /** This method returns instance for okCommand4 component and should be called instead of accessing okCommand4 field directly.//GEN-BEGIN:MVDGetBegin80
     * @return Instance for okCommand4 component
     */
    public Command get_okCommand4() {
        if (okCommand4 == null) {//GEN-END:MVDGetBegin80
            // Insert pre-init code here
            okCommand4 = new Command("Ok", Command.OK, 1);//GEN-LINE:MVDGetInit80
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd80
        return okCommand4;
    }//GEN-END:MVDGetEnd80

    /** This method returns instance for projeIsmiHataGonder component and should be called instead of accessing projeIsmiHataGonder field directly.//GEN-BEGIN:MVDGetBegin83
     * @return Instance for projeIsmiHataGonder component
     */
    public TextField get_projeIsmiHataGonder() {
        if (projeIsmiHataGonder == null) {//GEN-END:MVDGetBegin83
            // Insert pre-init code here
            projeIsmiHataGonder = new TextField("Proje ismini giriniz:", null, 120, TextField.ANY);//GEN-LINE:MVDGetInit83
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd83
        return projeIsmiHataGonder;
    }//GEN-END:MVDGetEnd83

    /** This method returns instance for lblSoru component and should be called instead of accessing lblSoru field directly.//GEN-BEGIN:MVDGetBegin84
     * @return Instance for lblSoru component
     */
    public StringItem get_lblSoru() {
        if (lblSoru == null) {//GEN-END:MVDGetBegin84
            // Insert pre-init code here
            lblSoru = new StringItem("Soru:", "");//GEN-LINE:MVDGetInit84
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd84
        return lblSoru;
    }//GEN-END:MVDGetEnd84

    /** This method returns instance for lblNot component and should be called instead of accessing lblNot field directly.//GEN-BEGIN:MVDGetBegin85
     * @return Instance for lblNot component
     */
    public StringItem get_lblNot() {
        if (lblNot == null) {//GEN-END:MVDGetBegin85
            // Insert pre-init code here
            lblNot = new StringItem("Not:", "");//GEN-LINE:MVDGetInit85
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd85
        return lblNot;
    }//GEN-END:MVDGetEnd85
 
    /** This method returns instance for bekletmeEkraniEvetSonraki component and should be called instead of accessing bekletmeEkraniEvetSonraki field directly.//GEN-BEGIN:MVDGetBegin89
     * @return Instance for bekletmeEkraniEvetSonraki component
     */
    public org.netbeans.microedition.lcdui.WaitScreen get_bekletmeEkraniEvetSonraki() {
        if (bekletmeEkraniEvetSonraki == null) {//GEN-END:MVDGetBegin89
            // Insert pre-init code here
            bekletmeEkraniEvetSonraki = new org.netbeans.microedition.lcdui.WaitScreen(getDisplay());//GEN-BEGIN:MVDGetInit89
            bekletmeEkraniEvetSonraki.setFailureDisplayable(get_hata(), get_bekletmeEkraniEvetSonraki());//GEN-END:MVDGetInit89
            bekletmeEkraniEvetSonraki.setNextDisplayable(get_soruGoster());
            bekletmeEkraniEvetSonraki.setTask(get_evetsonraki_Task());
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd89
        return bekletmeEkraniEvetSonraki;
    }//GEN-END:MVDGetEnd89

    /** This method returns instance for bekletmeEkraniHayirSonraki component and should be called instead of accessing bekletmeEkraniHayirSonraki field directly.//GEN-BEGIN:MVDGetBegin92
     * @return Instance for bekletmeEkraniHayirSonraki component
     */
    public org.netbeans.microedition.lcdui.WaitScreen get_bekletmeEkraniHayirSonraki() {
        if (bekletmeEkraniHayirSonraki == null) {//GEN-END:MVDGetBegin92
            // Insert pre-init code here
            bekletmeEkraniHayirSonraki = new org.netbeans.microedition.lcdui.WaitScreen(getDisplay());//GEN-BEGIN:MVDGetInit92
            bekletmeEkraniHayirSonraki.setFailureDisplayable(get_hata(), get_bekletmeEkraniHayirSonraki());//GEN-END:MVDGetInit92
            bekletmeEkraniHayirSonraki.setNextDisplayable(get_soruGoster());
            bekletmeEkraniHayirSonraki.setTask(get_hayirsonraki_Task());
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd92
        return bekletmeEkraniHayirSonraki;
    }//GEN-END:MVDGetEnd92

    /** This method returns instance for hataGondermeFormu component and should be called instead of accessing hataGondermeFormu field directly.//GEN-BEGIN:MVDGetBegin95
     * @return Instance for hataGondermeFormu component
     */
    public Form get_hataGondermeFormu() {
        if (hataGondermeFormu == null) {//GEN-END:MVDGetBegin95
            // Insert pre-init code here
            hataGondermeFormu = new Form("Hata gonderimi", new Item[] {//GEN-BEGIN:MVDGetInit95
                get_hataAciklama(),
                get_lblSoru1(),
                get_lblNot1()
            });
            hataGondermeFormu.addCommand(get_okCommand7());
            hataGondermeFormu.setCommandListener(this);//GEN-END:MVDGetInit95
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd95
        return hataGondermeFormu;
    }//GEN-END:MVDGetEnd95

    /** This method returns instance for hataAciklama component and should be called instead of accessing hataAciklama field directly.//GEN-BEGIN:MVDGetBegin96
     * @return Instance for hataAciklama component
     */
    public TextField get_hataAciklama() {
        if (hataAciklama == null) {//GEN-END:MVDGetBegin96
            // Insert pre-init code here
            hataAciklama = new TextField("Hata hakkinda ayrintili bilgi yaziniz:", "", 500, TextField.ANY);//GEN-LINE:MVDGetInit96
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd96
        return hataAciklama;
    }//GEN-END:MVDGetEnd96

    /** This method returns instance for okCommand7 component and should be called instead of accessing okCommand7 field directly.//GEN-BEGIN:MVDGetBegin97
     * @return Instance for okCommand7 component
     */
    public Command get_okCommand7() {
        if (okCommand7 == null) {//GEN-END:MVDGetBegin97
            // Insert pre-init code here
            okCommand7 = new Command("Ok", Command.OK, 1);//GEN-LINE:MVDGetInit97
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd97
        return okCommand7;
    }//GEN-END:MVDGetEnd97

    /** This method returns instance for bekletmeEkraniGonderim component and should be called instead of accessing bekletmeEkraniGonderim field directly.//GEN-BEGIN:MVDGetBegin99
     * @return Instance for bekletmeEkraniGonderim component
     */
    public org.netbeans.microedition.lcdui.WaitScreen get_bekletmeEkraniGonderim() {
        if (bekletmeEkraniGonderim == null) {//GEN-END:MVDGetBegin99
            // Insert pre-init code here
            bekletmeEkraniGonderim = new org.netbeans.microedition.lcdui.WaitScreen(getDisplay());//GEN-BEGIN:MVDGetInit99
            bekletmeEkraniGonderim.setFailureDisplayable(get_hata(), get_bekletmeEkraniGonderim());
            bekletmeEkraniGonderim.setTitle("Hata gonderiliyor, lutfen bekleyiniz...");
            bekletmeEkraniGonderim.setNextDisplayable(get_hataGondermeSonuc());//GEN-END:MVDGetInit99
            bekletmeEkraniGonderim.setTask(get_gonder_Task());
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd99
        return bekletmeEkraniGonderim;
    }//GEN-END:MVDGetEnd99
 
    /** This method returns instance for lblSoru1 component and should be called instead of accessing lblSoru1 field directly.//GEN-BEGIN:MVDGetBegin111
     * @return Instance for lblSoru1 component
     */
    public StringItem get_lblSoru1() {
        if (lblSoru1 == null) {//GEN-END:MVDGetBegin111
            // Insert pre-init code here
            lblSoru1 = new StringItem("", "");//GEN-LINE:MVDGetInit111
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd111
        return lblSoru1;
    }//GEN-END:MVDGetEnd111

    /** This method returns instance for lblNot1 component and should be called instead of accessing lblNot1 field directly.//GEN-BEGIN:MVDGetBegin112
     * @return Instance for lblNot1 component
     */
    public StringItem get_lblNot1() {
        if (lblNot1 == null) {//GEN-END:MVDGetBegin112
            // Insert pre-init code here
            lblNot1 = new StringItem("", "");//GEN-LINE:MVDGetInit112
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd112
        return lblNot1;
    }//GEN-END:MVDGetEnd112

    /** This method returns instance for hataGondermeSonuc component and should be called instead of accessing hataGondermeSonuc field directly.//GEN-BEGIN:MVDGetBegin113
     * @return Instance for hataGondermeSonuc component
     */
    public Form get_hataGondermeSonuc() {
        if (hataGondermeSonuc == null) {//GEN-END:MVDGetBegin113
            // Insert pre-init code here
            hataGondermeSonuc = new Form(null, new Item[] {get_hataGondermeSonuc1()});//GEN-BEGIN:MVDGetInit113
            hataGondermeSonuc.addCommand(get_okCommand8());
            hataGondermeSonuc.setCommandListener(this);//GEN-END:MVDGetInit113
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd113
        return hataGondermeSonuc;
    }//GEN-END:MVDGetEnd113

    /** This method returns instance for okCommand8 component and should be called instead of accessing okCommand8 field directly.//GEN-BEGIN:MVDGetBegin114
     * @return Instance for okCommand8 component
     */
    public Command get_okCommand8() {
        if (okCommand8 == null) {//GEN-END:MVDGetBegin114
            // Insert pre-init code here
            okCommand8 = new Command("Ok", Command.OK, 1);//GEN-LINE:MVDGetInit114
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd114
        return okCommand8;
    }//GEN-END:MVDGetEnd114

    /** This method returns instance for hataGondermeSonuc1 component and should be called instead of accessing hataGondermeSonuc1 field directly.//GEN-BEGIN:MVDGetBegin116
     * @return Instance for hataGondermeSonuc1 component
     */
    public StringItem get_hataGondermeSonuc1() {
        if (hataGondermeSonuc1 == null) {//GEN-END:MVDGetBegin116
            // Insert pre-init code here
            hataGondermeSonuc1 = new StringItem("", "");//GEN-LINE:MVDGetInit116
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd116
        return hataGondermeSonuc1;
    }//GEN-END:MVDGetEnd116

    /** This method returns instance for bekletmeEkraniGiris component and should be called instead of accessing bekletmeEkraniGiris field directly.//GEN-BEGIN:MVDGetBegin122
     * @return Instance for bekletmeEkraniGiris component
     */
    public org.netbeans.microedition.lcdui.WaitScreen get_bekletmeEkraniGiris() {
        if (bekletmeEkraniGiris == null) {//GEN-END:MVDGetBegin122
            // Insert pre-init code here
            bekletmeEkraniGiris = new org.netbeans.microedition.lcdui.WaitScreen(getDisplay());//GEN-BEGIN:MVDGetInit122
            bekletmeEkraniGiris.setFailureDisplayable(get_hata(), get_bekletmeEkraniGiris());//GEN-END:MVDGetInit122
            bekletmeEkraniGiris.setTask(get_giris_Task());
        }//GEN-BEGIN:MVDGetEnd122
        return bekletmeEkraniGiris;
    }//GEN-END:MVDGetEnd122

    /** This method returns instance for girisFormu component and should be called instead of accessing girisFormu field directly.//GEN-BEGIN:MVDGetBegin125
     * @return Instance for girisFormu component
     */
    public Form get_girisFormu() {
        if (girisFormu == null) {//GEN-END:MVDGetBegin125
            // Insert pre-init code here
            girisFormu = new Form(null, new Item[] {//GEN-BEGIN:MVDGetInit125
                get_txtIsim(),
                get_txtSifre()
            });
            girisFormu.addCommand(get_okCommand9());
            girisFormu.addCommand(get_exitCommand3());
            girisFormu.setCommandListener(this);//GEN-END:MVDGetInit125
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd125
        return girisFormu;
    }//GEN-END:MVDGetEnd125

    /** This method returns instance for okCommand9 component and should be called instead of accessing okCommand9 field directly.//GEN-BEGIN:MVDGetBegin126
     * @return Instance for okCommand9 component
     */
    public Command get_okCommand9() {
        if (okCommand9 == null) {//GEN-END:MVDGetBegin126
            // Insert pre-init code here
            okCommand9 = new Command("Ok", Command.OK, 1);//GEN-LINE:MVDGetInit126
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd126
        return okCommand9;
    }//GEN-END:MVDGetEnd126

    /** This method returns instance for txtIsim component and should be called instead of accessing txtIsim field directly.//GEN-BEGIN:MVDGetBegin131
     * @return Instance for txtIsim component
     */
    public TextField get_txtIsim() {
        if (txtIsim == null) {//GEN-END:MVDGetBegin131
            // Insert pre-init code here
            txtIsim = new TextField("Kullan\u0131c\u0131 ismi:", "", 20, TextField.ANY);//GEN-LINE:MVDGetInit131
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd131
        return txtIsim;
    }//GEN-END:MVDGetEnd131

    /** This method returns instance for txtSifre component and should be called instead of accessing txtSifre field directly.//GEN-BEGIN:MVDGetBegin132
     * @return Instance for txtSifre component
     */
    public TextField get_txtSifre() {
        if (txtSifre == null) {//GEN-END:MVDGetBegin132
            // Insert pre-init code here
            txtSifre = new TextField("\u015Eifre", "", 10, TextField.ANY | TextField.PASSWORD);//GEN-LINE:MVDGetInit132
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd132
        return txtSifre;
    }//GEN-END:MVDGetEnd132

    /** This method returns instance for exitCommand3 component and should be called instead of accessing exitCommand3 field directly.//GEN-BEGIN:MVDGetBegin133
     * @return Instance for exitCommand3 component
     */
    public Command get_exitCommand3() {
        if (exitCommand3 == null) {//GEN-END:MVDGetBegin133
            // Insert pre-init code here
            exitCommand3 = new Command("Exit", Command.EXIT, 1);//GEN-LINE:MVDGetInit133
            // Insert post-init code here
        }//GEN-BEGIN:MVDGetEnd133
        return exitCommand3;
    }//GEN-END:MVDGetEnd133
     
    public void startApp() {
    }
    
    public void pauseApp() {
    }
    
    public void destroyApp(boolean unconditional) {
    }
    
}
