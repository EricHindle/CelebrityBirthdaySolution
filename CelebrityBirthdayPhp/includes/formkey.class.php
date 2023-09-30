<?php
 
class formKey
{
    private $formKey;
    private $old_formKey;
     
    function __construct()
    {
        if(isset($_SESSION['form_key']))
        {
            $this->old_formKey = $_SESSION['form_key'];
        }
    }
 
    private function generateKey()
    {
        if (getenv('HTTP_X_REAL_IP')) {
            $ip = getenv('HTTP_X_REAL_IP');
        }
        
        else {
            $ip = $_SERVER['REMOTE_ADDR'];
        }
        $uniqid = uniqid(mt_rand(), true);
         
        return md5($ip . $uniqid);
    }
 
    public function outputKey()
    {
        $this->formKey = $this->generateKey();
        $_SESSION['form_key'] = $this->formKey;
        return "<input type='hidden' name='form_key' id='form_key' value='".$this->formKey."' />";
    }
 
     
    public function validate()
    {
        if(isset($_SESSION['form_key']) && $_POST['form_key'] == $this->old_formKey)
        {
        	$_SESSION['form_key']=null;
        	$old_formKey=null;
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public function validate_get()
    {
        if(isset($_SESSION['form_key']) && $_GET['form_key'] == $this->old_formKey)
        {
            $_SESSION['form_key']=null;
            $old_formKey=null;
            return true;
        }
        else
        {
            return false;
        }
    }
}
?>