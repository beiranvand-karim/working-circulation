package stringcombinatioinsgenerator;

import javafx.geometry.Pos;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.layout.VBox;
import javafx.stage.Modality;
import javafx.stage.Stage;

public class ConfirmBox {
    static boolean answer;

    public static boolean display(String title, String message)  {
        Stage window= new Stage();
        window.initModality(Modality.APPLICATION_MODAL);
        window.setTitle(title);
        window.setMinWidth(250);
        window.setMinHeight(400);

        Label label =  new Label();
        label.setText(message);

        Button yesButton  = new Button("yes");
        Button noButton  = new Button("no");
        yesButton.setOnAction(event -> {
            answer = true;
            window.close();
        });
        noButton.setOnAction(event -> {
            answer = false;
            window.close();
        });

        VBox vbox = new VBox();
        vbox.getChildren().addAll(label, yesButton, noButton);
        vbox.setAlignment(Pos.CENTER);

        Scene scene = new Scene(vbox);
        scene.getStylesheets().add(App.class.getResource("application.css").toExternalForm());
        window.setScene(scene);
        window.showAndWait();

        return answer;
    }
}
