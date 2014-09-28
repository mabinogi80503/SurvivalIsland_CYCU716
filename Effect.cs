using UnityEngine;
using System.Collections;

public class Effect {
	public GameObject player ;

	public Effect( GameObject obj ) {
		player = obj ;
	}

	public void ModifiedHP( float num ) {
		VitalAttr health = player.GetComponent<PlayerCharacter>().GetVitalAttr("Health") ;
		if ( num > 0.0f ) health.IncreaseCurValue( num ) ;
		else health.DecreaseCurValue( num ) ;
	} 

	public void ModifiedStamina( float num ) {
        VitalAttr stamina = player.GetComponent<PlayerCharacter>().GetVitalAttr( "Stamina" );
		if ( num > 0.0f ) stamina.IncreaseCurValue( num ) ;
		else stamina.DecreaseCurValue( num ) ;
	} 

	public void ModifiedMental( float num ) {
        VitalAttr mental = player.GetComponent<PlayerCharacter>().GetVitalAttr( "Mental" );
		if ( num > 0.0f ) mental.IncreaseCurValue( num ) ;
		else mental.DecreaseCurValue( num ) ;
	} 

	public void GiveExp( int exp ) {
        player.GetComponent<PlayerCharacter>().AddExp( exp );
	}

	public void AnalysisSpeedUp( float percent ) {
        player.GetComponent<PlayerCharacter>().GetHideAttr( "AnalysisSpeed" ).AddAttrLastRadio( percent );
	}

	public void ColletionSpeedUp( float percent ) {
        player.GetComponent<PlayerCharacter>().GetHideAttr( "ColletionSpeed" ).AddAttrLastRadio( percent );
	}
}
