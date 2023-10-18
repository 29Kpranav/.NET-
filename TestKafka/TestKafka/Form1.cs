using Confluent.Kafka;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestKafka
{
    public partial class Form1 : Form
    {
        private string bootstrapServers = "localhost:9092";
        private string topicName = "CsharpSpacekafkaTopic";

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                MessageBox.Show("Please enter a message.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string message = txtMessage.Text.Trim();

            // Create a producer configuration
            var producerConfig = new ProducerConfig
            {
                BootstrapServers = "localhost:9092"
                // Add other configuration options as needed
            };

            // Create a producer instance
            using (var producer = new ProducerBuilder<Null, string>(producerConfig).Build())
            {
                // Create a message to send
                var kafkaMessage = new Message<Null, string>
                {
                    Value = message
                };

                // Send the message to the topic
                var deliveryReport = await producer.ProduceAsync("CsharpSpacekafkaTopic", kafkaMessage);

                MessageBox.Show($"Message sent to Kafka. Partition: {deliveryReport.Partition}, Offset: {deliveryReport.Offset}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Clear();
        }

        private void Clear()
        {
            txtMessage.Text = string.Empty;
            txtMessage.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
//.\bin\windows\zookeeper-server-start.bat .\config\zookeeper.properties
//.\bin\windows\kafka-server-start.bat .\config\server.properties
//kafka-console-consumer.bat --bootstrap-servrer localhost:9092 --topic CsharpSpaceKafkaTopic --fron-beginning








/*
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Confluent.Kafka;

namespace TestKafka
{
    public partial class Form1 : Form
    {
        private string bootstrapServers = "localhost:9092";
        private string topicName = "CsharpSpacekafkaTopic";

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                MessageBox.Show("Please enter a message.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string payload = txtMessage.Text.Trim();

            var config = new ProducerConfig { BootstrapServers = bootstrapServers };
            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                var message = new Message<Null, string> { Value = payload };
                await producer.ProduceAsync(topicName, message);
            }

            Clear();
        }

        private void Clear()
        {
            txtMessage.Text = string.Empty;
            txtMessage.Focus();
        }
    }
}

*/

